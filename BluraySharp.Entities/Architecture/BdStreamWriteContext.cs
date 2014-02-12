using System;
using System.IO;

namespace BluraySharp.Architecture
{
	public class BdStreamWriteContext : BdStreamIoContext, IBdRawWriteContext
	{
		public BdStreamWriteContext(Stream stream)
			:base(stream)
		{}

		public void Serialize<T>(T obj) where T : IBdRawSerializable
		{
			throw new NotImplementedException();
		}

		public void SerializeStruct<T>(ref T obj) where T : struct
		{
			
		}

		public void Serialize(byte[] value)
		{
			throw new NotImplementedException();
		}

		public void Serialize(string value)
		{
			throw new NotImplementedException();
		}

		public void Serialize(byte value)
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
	}
}
