using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BluraySharp.Architecture
{
	public abstract class BdStreamIoContext : IBdRawIoContext
	{
		private Stream bdStream;

		private long length;
		public long Length
		{
			get
			{
				lock (this.snapshotLocker)
				{
					return this.length;
				}
			}
		}

		public long Position
		{
			get
			{
				lock (this.snapshotLocker)
				{
					return this.ioCount - this.baseAddress;
				}
			}
			set
			{
				lock (this.snapshotLocker)
				{
					long tIoCount = this.baseAddress + value;
					long tDelta = tIoCount - ioCount;

					if (tDelta == 0)
					{
						return;
					}
					else if (this.bdStream.CanSeek)
					{
						this.bdStream.Position = this.ioCount = tIoCount;

						return;
					}
					else if (tDelta > 0)
					{
						const int tBufferSize = 4096 * 16;
						byte[] tBuffer = new byte[tBufferSize];
						while(tDelta > 0)
						{
							tDelta -= bdStream.Read(tBuffer, 0, (int) Math.Min(tBufferSize, tDelta));
						}
					}
					else
					{
						//Cannot seek back on a non-random-access stream.
						throw new NotSupportedException();
					}
				}
			}
		}

		private long baseAddress = 0;
		private long ioCount = 0;

		public BdStreamIoContext(Stream stream)
		{
			this.bdStream = stream;
			this.length = this.bdStream.CanSeek ? bdStream.Length : -1;
		}

		~BdStreamIoContext()
		{
		}

		protected int Read(byte[] buffer, int offset, int length)
		{
			lock (this.snapshotLocker)
			{
				long tLength = (this.Length != -1) ? (this.Length - this.Position) : length;
				tLength = Math.Min(tLength, length);

				int tRet = bdStream.Read(buffer, offset, (int)tLength);
				this.ioCount += tRet;
				return tRet;
			}
		}

		protected void Write(byte[] buffer, int offset, int length)
		{
			lock (this.snapshotLocker)
			{
				long tLength = (this.Length != -1) ? (this.Length - this.Position) : length;
				tLength = Math.Min(tLength, length);

				bdStream.Write(buffer, offset, (int)tLength);
				this.ioCount += length;
				return;
			}
		}

		private object snapshotLocker = new object();
		private bool isLengthSpecified = false;
		private readonly Stack<BdRawSerializingScopeSnapshot> snapshotStack = new Stack<BdRawSerializingScopeSnapshot>();

		public class BdRawSerializingScopeSnapshot
		{
			public BdRawSerializingScopeSnapshot(BdStreamIoContext scope)
			{
				this.BaseAddress = scope.baseAddress;
				this.IoCount = scope.ioCount;

				this.Length = scope.length;
				this.IsLengthSpecified = scope.isLengthSpecified;
			}

			public long BaseAddress { get; private set; }
			public long IoCount { get; private set; }

			public long Length { get; private set; }
			public bool IsLengthSpecified { get; private set; }
		}


		public void EnterScope(long length)
		{
			lock (this.snapshotLocker)
			{
				if (length < 0)
				{
					//positive value required
					throw new ArgumentException("length");
				}

				//required scope is beyond the left area.
				if (this.length != -1 && this.Position + length > this.length)
				{
					throw new ArgumentOutOfRangeException("length");
				}

				this.EnterScopeInternal(length, true);
			}
		}

		public void EnterScope()
		{
			lock (this.snapshotLocker)
			{
				long tLen = this.length;
				if (tLen != -1)
				{
					tLen -= this.Position;
				}

				this.EnterScopeInternal(tLen, false);
			}
		}

		private void EnterScopeInternal(long length, bool isLengthSpecified)
		{
			lock (this.snapshotLocker)
			{
				this.snapshotStack.Push(new BdRawSerializingScopeSnapshot(this));

				this.baseAddress = this.ioCount;

				this.length = length;
				this.isLengthSpecified = isLengthSpecified;
			}
		}

		public void ExitScope(long length)
		{
			lock (this.snapshotLocker)
			{
				if (length < 0)
				{
					//positive value required
					throw new ArgumentException("length");
				}

				if (this.isLengthSpecified && this.Length != length)
				{
					//Scope length specified twice with different value.
					throw new InvalidOperationException();
				}

				this.ExitScopeInternal(length);
			}
		}

		public void ExitScope()
		{
			lock (this.snapshotLocker)
			{
				if (this.isLengthSpecified)
				{
					//Exit from current position
					this.ExitScopeInternal(this.Position);
				}
				else
				{
					//Exit with length specified on entering.
					this.ExitScopeInternal(this.Length);
				}
			}
		}

		private void ExitScopeInternal(long length)
		{
			lock (this.snapshotLocker)
			{
				BdRawSerializingScopeSnapshot tSnapshot = this.snapshotStack.Pop();

				this.baseAddress = tSnapshot.BaseAddress;
				this.ioCount = tSnapshot.IoCount;

				this.length = tSnapshot.Length;
				this.isLengthSpecified = tSnapshot.IsLengthSpecified;

				this.Position += length;
			}
		}

		/*
		public void Serialize<T>(T obj) where T : IBdRawSerializable
		{
			if (object.ReferenceEquals(obj, null))
			{
				throw new ArgumentNullException("obj");
			}

			long tOffset = 0;
			this.EnterScope(obj.RawLength);
			try
			{
				tOffset = obj.SerializeTo(this);
			}
			finally
			{
				this.ExitScope();
				scope.Offset += tOffset;
			}
		}

		public T Deserialize<T>() where T : IBdRawSerializable, new()
		{
			T tObject = new T();

			this.Deserialize<T>(tObject);
			return tObject;
		}

		public void Deserialize<T>(T obj) where T : IBdRawSerializable
		{
			long tOffset = 0;
			this.EnterScope();
			try
			{
				tOffset = obj.DeserializeFrom(this);
			}
			finally
			{
				this.ExitScope();
				scope.Offset += tOffset;
			}
		}

		private byte[] DeserializeBytesReversed(int len)
		{
			byte[] tBuffer = this.DeserializeBytes(len);

			tBuffer = tBuffer.Reverse().ToArray();
			return tBuffer;
		}

		public byte DeserializeByte()
		{
			byte tRet = this.DeserializeBytes(1)[0];

			return tRet;
		}

		public ushort DeserializeUInt16()
		{
			byte[] tBuffer = DeserializeBytesReversed(2);

			return BitConverter.ToUInt16(tBuffer, 0);
		}

		public uint DeserializeUInt32()
		{
			byte[] tBuffer = DeserializeBytesReversed(4);

			return BitConverter.ToUInt32(tBuffer, 0);
		}

		public ulong DeserializeUInt64()
		{
			byte[] tBuffer = DeserializeBytesReversed(8);

			return BitConverter.ToUInt64(tBuffer, 0);
		}

		public byte[] DeserializeBytes(int len)
		{
			byte[] tBuffer = new byte[len];

			this.BdStream.Read(tBuffer, 0, len);
			scope.Offset += len;

			return tBuffer;
		}

		public string DeserializeString(int len)
		{
			return Encoding.UTF8.GetString(this.DeserializeBytes(len));
		}

		public T DeserializeStruct<T>() where T : new()
		{
			T tObj = (T)scope.Buffer.GetStructure(scope.Offset, typeof(T));
			scope.Offset += Marshal.SizeOf(tObj);
			return tObj;
		}

		public void EnterScope(long length)
		{
			throw new NotImplementedException();
		}

		public void ExitScope(long length)
		{
			throw new NotImplementedException();
		}

		public void Serialize(byte value)
		{
			throw new NotImplementedException();
		}

		public void Serialize(byte[] value)
		{
			throw new NotImplementedException();
		}

		public void Serialize(ushort value)
		{
			throw new NotImplementedException();
		}

		public void Serialize(uint value)
		{
			throw new NotImplementedException();
		}

		public void Serialize(ulong value)
		{
			throw new NotImplementedException();
		}

		public void Serialize<T>(T obj) where T : IBdRawSerializable
		{
			throw new NotImplementedException();
		}

		public void SerializeStruct<T>(T obj)
		{
			throw new NotImplementedException();
		}
		*/
	}
}
