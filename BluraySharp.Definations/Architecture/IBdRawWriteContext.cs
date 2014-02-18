using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Architecture
{
	public interface IBdRawWriteContext : IBdRawIoContext
	{
		void Serialize(IBdRawSerializable obj);

		void Serialize(byte[] value, int offset, int length);
		void Serialize(byte[] value);

		void SerializeUInt(ulong value, BdIntSize size);
	}
}
