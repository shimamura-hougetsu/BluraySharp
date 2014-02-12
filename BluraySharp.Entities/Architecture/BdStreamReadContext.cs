using System;
using System.IO;
using System.Linq;
using System.Text;

namespace BluraySharp.Architecture
{
	public class BdStreamReadContext : BdStreamIoContext, IBdRawReadContext
	{
		public BdStreamReadContext(Stream stream)
			:base(stream)
		{}

		public int Deserialize(byte[] buffer, int offset, int length)
		{
			return base.Read(buffer, offset, length);
		}

		public void Deserialize<T>(T obj) where T : IBdRawSerializable
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

		public byte[] DeserializeBytes(int length)
		{
			byte[] tBuffer = new byte[length];
			int tLastReadLen = -1, tReadLen = 0;
			while (tReadLen < length && tLastReadLen != 0)
			{
				tLastReadLen = this.Deserialize(tBuffer, tReadLen, length - tReadLen);
				tReadLen += tLastReadLen;
			}

			if (tReadLen != length)
			{
				//TODO: not expected stream end.
				throw new Exception();
			}

			return tBuffer;
		}

		public string DeserializeString(int len)
		{
			return Encoding.UTF8.GetString(this.DeserializeBytes(len));
		}

		private byte[] DeserializeBytesReversed(int length)
		{
			byte[] tBuffer = DeserializeBytes(length);

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
			byte[] tBuffer = this.DeserializeBytesReversed(2);

			return BitConverter.ToUInt16(tBuffer, 0);
		}

		public uint DeserializeUInt32()
		{
			byte[] tBuffer = this.DeserializeBytesReversed(4);

			return BitConverter.ToUInt32(tBuffer, 0);
		}

		public ulong DeserializeUInt64()
		{
			byte[] tBuffer = this.DeserializeBytesReversed(8);

			return BitConverter.ToUInt64(tBuffer, 0);
		}
	}
}
