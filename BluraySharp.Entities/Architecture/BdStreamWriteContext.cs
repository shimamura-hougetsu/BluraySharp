using System;
using System.Linq;
using System.IO;
using System.Text;

namespace BluraySharp.Architecture
{
	public class BdStreamWriteContext : BdStreamIoContext, IBdRawWriteContext
	{
		public BdStreamWriteContext(Stream stream)
			:base(stream)
		{}

		public void Serialize(byte[] buffer, int offset, int length)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("value");
			}

			this.Write(buffer, 0, length);
		}

		public void Serialize(IBdRawSerializable obj)
		{
			this.EnterScope();
			try
			{
				this.Position = obj.SerializeTo(this);
			}
			finally
			{
				this.ExitScope();
			}
		}

		public void Serialize(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("value");
			}

			this.Write(buffer, 0, buffer.Length);
		}

		public void SerializeBytes(byte[] value)
		{
			throw new NotImplementedException();
		}

		public void SerializeUInt(ulong value, BdIntSize size)
		{
			const int tBufferSize = sizeof(ulong);
			int tSize = (int)size;

			byte[] tBuffer = BitConverter.GetBytes(value).Reverse().ToArray();
			this.Write(tBuffer, tBufferSize - tSize, tSize);
		}

		public override void Skip(long delta)
		{
			const int tBufferSize = 4096 * 16;
			byte[] tBuffer = new byte[tBufferSize];
			while (delta > 0)
			{
				int tLen = (int) Math.Min(tBufferSize, delta);
				base.Write(tBuffer, 0, tLen);
				delta -= tLen;
			}
		}
	}
}
