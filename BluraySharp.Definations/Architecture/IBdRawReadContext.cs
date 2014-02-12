using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Architecture
{
	public interface IBdRawReadContext : IBdRawIoContext
	{
		T Deserialize<T>() where T : IBdRawSerializable, new();
		void Deserialize<T>(T obj) where T : IBdRawSerializable;

		T DeserializeStruct<T>(out T obj) where T : struct;

		byte[] DeserializeBytes(int len);

		string DeserializeString(int len);

		byte DeserializeByte();
		ushort DeserializeUInt16();
		uint DeserializeUInt32();
		ulong DeserializeUInt64();
	}
}
