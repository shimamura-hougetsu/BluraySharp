
using BluraySharp.Common;
using System.Text;
namespace BluraySharp.Common.Serializing
{
	public interface IBdRawReadContext : IBdRawIoContext
	{
		void Deserialize(IBdRawSerializable obj);

		void Deserialize(byte[] value);
		void Deserialize(byte[] value, int offset, int length);
		
		ulong Deserialize(BdIntSize intSize);

		string Deserialize(int byteCount, Encoding encoding);
	}
}
