using System;
namespace BluraySharp
{
	public interface IBdRawSerializeContext
	{
		T Deserialize<T>() where T : IBdRawSerializable, new();
		byte DeserializeByte();
		byte[] DeserializeBytes(int len);
		string DeserializeString(int len);
		T DeserializeStruct<T>() where T : new();
		ushort DeserializeUInt16();
		uint DeserializeUInt32();
		ulong DeserializeUInt64();
		void EnterScope();
		void EnterScope(long length);
		void ExitScope();
		long Length { get; }
		long Offset { get; set; }
		void Serialize(byte value);
		void Serialize(byte[] value);
		void Serialize(ushort value);
		void Serialize(uint value);
		void Serialize(ulong value);
		void Serialize<T>(T obj) where T : IBdRawSerializable;
		void SerializeStruct<T>(T obj);
	}
}
