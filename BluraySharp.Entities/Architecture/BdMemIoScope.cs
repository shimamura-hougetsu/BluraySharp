using System;
using System.Collections.Generic;
using System.Linq;
using LibElfin.WinApi;
using LibElfin.WinApi.MemoryBlock;

namespace BluraySharp.Architecture
{
	internal class BdMemIoScope : IDisposable
	{
		public BdMemIoScope(MemBlock buffer)
		{
			this.Buffer = buffer;
			this.Offset = 0;
		}

		public MemBlock Buffer { get; private set; }
		public MemOffset Offset { get; set; }

		private readonly Stack<BdRawSerializingScopeSnapshot> snapshotStack = new Stack<BdRawSerializingScopeSnapshot>();

		public void EnterScope(long length)
		{
			MemOffset tLen = this.Buffer.Length - this.Offset;
			if (length <= tLen)
			{
				tLen = length;
			}
			else
			{
				throw new ArgumentOutOfRangeException("length");
			}

			BdRawSerializingScopeSnapshot tSnapshot = new BdRawSerializingScopeSnapshot(this);
			
			this.Buffer = new MemBlockRef(this.Buffer, this.Offset, tLen);
			this.Offset = 0;

			this.snapshotStack.Push(tSnapshot);
		}

		public void ExitScope()
		{
			BdRawSerializingScopeSnapshot tSnapshot = this.snapshotStack.Pop();

			this.Buffer.Dispose();
			this.Buffer = tSnapshot.Buffer;
			this.Offset = tSnapshot.Offset;
		}

		public void Dispose()
		{
			this.Dispose(true);

			GC.SuppressFinalize(this);
		}

		~BdMemIoScope()
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
					while (snapshotStack.Any())
					{
						this.ExitScope();
					}

					Offset = 0;
				}

				this.isDisposed = true;
			}
		}

		public class BdRawSerializingScopeSnapshot
		{
			public BdRawSerializingScopeSnapshot(BdMemIoScope scope)
			{
				this.Buffer = scope.Buffer;
				this.Offset = scope.Offset;
			}

			public MemBlock Buffer { get; private set; }
			public MemOffset Offset { get; private set; }
		}
	}
}
