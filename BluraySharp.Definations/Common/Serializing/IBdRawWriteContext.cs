using System.Text;

namespace BluraySharp.Common.Serializing
{
	public interface IBdRawWriteContext : IBdRawIoContext
	{
		void Serialize(IBdRawSerializable obj);

		void Serialize(byte[] value, int offset, int length);
		void Serialize(byte[] value);

		void Serialize(ulong value, BdIntSize size);

		void Serialize(string value, int byteCount, Encoding encoding);
	}
}
