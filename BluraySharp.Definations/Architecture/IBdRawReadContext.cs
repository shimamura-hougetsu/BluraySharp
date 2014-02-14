using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Architecture
{
	public interface IBdRawReadContext : IBdRawIoContext
	{
		void Deserialize(IBdRawSerializable obj);

		int Deserialize(byte[] value, int offset, int length);

		string DeserializeString(int length, Encoding encoding);
		byte[] DeserializeBytes(int length);

		byte DeserializeByte();
		ushort DeserializeUInt16();
		uint DeserializeUInt32();
		ulong DeserializeUInt64();
	}
}
