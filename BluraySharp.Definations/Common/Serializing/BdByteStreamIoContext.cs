using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BluraySharp.Common.Serializing;

namespace BluraySharp.Architecture
{
	public abstract class BdByteStreamIoContext : IBdRawIoContext
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
						this.Skip(tDelta);
					}
					else
					{
						//Cannot seek back on a non-random-access stream.
						throw new NotSupportedException();
					}
				}
			}
		}

		public abstract void Skip(long delta);

		private long baseAddress = 0;
		private long ioCount = 0;

		public BdByteStreamIoContext(Stream stream)
		{
			this.bdStream = stream;
			this.length = (this.bdStream.CanSeek && !this.bdStream.CanWrite) ? bdStream.Length : -1;
		}

		~BdByteStreamIoContext()
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
				this.ioCount += tLength;
				return;
			}
		}

		private object snapshotLocker = new object();
		private bool isLengthSpecified = false;
		private readonly Stack<BdRawSerializingScopeSnapshot> snapshotStack = new Stack<BdRawSerializingScopeSnapshot>();

		public class BdRawSerializingScopeSnapshot
		{
			public BdRawSerializingScopeSnapshot(BdByteStreamIoContext scope)
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
					//Exit from current position
					this.ExitScopeInternal(this.Position);
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
	}
}
