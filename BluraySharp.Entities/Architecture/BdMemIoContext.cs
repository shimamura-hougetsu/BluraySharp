using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using LibElfin.WinApi.MemoryBlock;

namespace BluraySharp.Architecture
{
	public class BdMemIoContext : IDisposable, IBdRawIoContext
	{
		public BdMemIoContext(MemBlock memory)
		{
			scope = new BdMemIoScope(memory);
		}

		public long Offset
		{
			get
			{
				return scope.Offset.ToInt64();
			}
			set
			{
				scope.Offset = value;
			}
		}

		public long Length
		{
			get
			{
				return scope.Buffer.Length.ToInt64();
			}
		}

		#region Scope

		private BdMemIoScope scope;
		
		public void EnterScope()
		{
			this.EnterScope(this.Length);
		}

		public void EnterScope(long length)
		{
			this.scope.EnterScope(length);
		}

		public void ExitScope()
		{
			this.scope.ExitScope();
		}

		#endregion Scope

		public void Serialize<T>(T obj) where T : IBdRawSerializable
		{
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

			long tOffset = 0;
			this.EnterScope();
			try
			{
				tOffset = tObject.DeserializeFrom(this);
			}
			finally
			{
				this.ExitScope();
				scope.Offset += tOffset;
			}

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

		#region Deserialize

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

			scope.Buffer.CopyTo(scope.Offset, tBuffer, 0, len);
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

		#endregion Deserialize

		#region Serialize

		private void SerializeBytesReversed(byte[] bytes)
		{
			byte[] tBuffer = bytes.Reverse().ToArray();
			this.Serialize(tBuffer);
		}

		public void Serialize(byte value)
		{
			Serialize(new byte[1]{value});
		}

		public void Serialize(ushort value)
		{
			SerializeBytesReversed(BitConverter.GetBytes(value));
		}

		public void Serialize(uint value)
		{
			this.SerializeBytesReversed(BitConverter.GetBytes(value));
		}

		public void Serialize(ulong value)
		{
			this.SerializeBytesReversed(BitConverter.GetBytes(value));
		}

		public void Serialize(byte[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			scope.Buffer.CopyFrom(scope.Offset, value, 0, value.Length);
			scope.Offset += value.Length;
		}

		public void SerializeStruct<T>(T obj)
		{
			scope.Buffer.WriteStructure(scope.Offset, obj);
			scope.Offset += Marshal.SizeOf(obj);
		}

		#endregion

		public void Dispose()
		{
			this.Dispose(true);

			GC.SuppressFinalize(this);
		}

		~BdMemIoContext()
		{
			this.Dispose(false);
		}

		private bool isDisposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.isDisposed)
			{
				if (disposing)
				{
					if(this.scope != null)
					{
						this.scope.Dispose();
						this.scope = null;
					}
				}

				isDisposed = true;
			}
		}
	}
}
