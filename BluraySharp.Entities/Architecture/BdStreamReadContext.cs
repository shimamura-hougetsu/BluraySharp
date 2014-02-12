using System;
using System.IO;

namespace BluraySharp.Architecture
{
	public class BdStreamReadContext : BdStreamIoContext, IBdRawReadContext
	{
		public BdStreamReadContext(Stream stream)
			:base(stream)
		{}

		public T Deserialize<T>() where T : IBdRawSerializable, new()
		{
			throw new NotImplementedException();
		}

		public void Deserialize<T>(T obj) where T : IBdRawSerializable
		{
			throw new NotImplementedException();
		}

		public T DeserializeStruct<T>(out T obj) where T : struct
		{
			throw new NotImplementedException();
		}

		public byte[] DeserializeBytes(int len)
		{
			byte[] tBuffer = new byte[len];

			base.Read(tBuffer, 0, len);
			this.Position += len;

			return tBuffer;
		}

		public string DeserializeString(int len)
		{
			throw new NotImplementedException();
		}

		public byte DeserializeByte()
		{
			throw new NotImplementedException();
		}

		public ushort DeserializeUInt16()
		{
			throw new NotImplementedException();
		}

		public uint DeserializeUInt32()
		{
			throw new NotImplementedException();
		}

		public ulong DeserializeUInt64()
		{
			throw new NotImplementedException();
		}
	}
}
