using BluraySharp.Common.Serializing;

namespace BluraySharp.Common.BdPartRawIoHelper
{
	internal interface IBdRawIoHelper<T>
	{
		long GetRawLength(T obj);

		long SerializeTo(T obj, IBdRawWriteContext context);

		long DeserializeFrom(T obj, IBdRawReadContext context);
	}

}
