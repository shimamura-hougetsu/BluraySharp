
using BluraySharp.Common;
namespace BluraySharp.Serializing
{
	public interface IBdRawReadContext : IBdRawIoContext
	{
		void Deserialize(IBdRawSerializable obj);

		void Deserialize(byte[] value);
		void Deserialize(byte[] value, int offset, int length);
		
		ulong Deserialize(BdIntSize intSize);
	}
}
