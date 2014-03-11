using BluraySharp.Common;
using BluraySharp.Common.Serializing;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace BluraySharp.Architecture
{
	public class BdByteStreamReadContext : BdByteStreamIoContext, IBdRawReadContext
	{
		public BdByteStreamReadContext(Stream stream)
			:base(stream)
		{}
		
		public void Deserialize(IBdRawSerializable obj)
		{
			this.EnterScope();
			try
			{
				this.Position = obj.DeserializeFrom(this);
			}
			finally
			{
				this.ExitScope();
			}
		}

		public void Deserialize(byte[] buffer, int offset, int length)
		{
			int tLastReadLen = -1, tReadLen = 0;

			while (tReadLen < length && tLastReadLen != 0)
			{
				tLastReadLen = this.Read(buffer, offset + tReadLen, length - tReadLen);
				tReadLen += tLastReadLen;
			}

			if (tReadLen != length)
			{
				//TODO: not expected stream end.
				throw new Exception();
			}
		}

		public void Deserialize(byte[] buffer)
		{
			this.Deserialize(buffer, 0, buffer.Length);
		}

		public ulong Deserialize(BdIntSize size)
		{
			const int tBufferSize = 8;
			int tSize = (int) size;

			byte[] tBuffer = new byte[tBufferSize];

			this.Deserialize(tBuffer, tBufferSize - tSize, tSize);
			tBuffer = tBuffer.Reverse().ToArray();

			return BitConverter.ToUInt64(tBuffer, 0);
		}

		public string Deserialize(int byteCount, Encoding encoding)
		{
			byte[] tBuffer = new byte[byteCount];
			this.Deserialize(tBuffer);
			return encoding.GetString(tBuffer);
		}

		public override void Skip(long delta)
		{
			const int tBufferSize = 4096 * 16;
			byte[] tBuffer = new byte[tBufferSize];
			while (delta > 0)
			{
				delta -= base.Read(tBuffer, 0, (int)Math.Min(tBufferSize, delta));
			}
		}
	}
}
