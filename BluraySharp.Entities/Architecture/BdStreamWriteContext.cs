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

		public void Serialize<T>(T obj) where T : IBdRawSerializable
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

		public void Serialize(string value)
		{
			this.Serialize(Encoding.UTF8.GetBytes(value));
		}

		private void SerializeBytesReversed(byte[] bytes)
		{
			byte[] tBuffer = bytes.Reverse().ToArray();
			this.Serialize(tBuffer, 0, bytes.Length);
		}

		public void Serialize(byte value)
		{
			SerializeBytesReversed(new byte[1] { value });
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


	}
}
