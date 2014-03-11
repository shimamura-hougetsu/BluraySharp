using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnAuEntry : IPlStnEntry
	{
		BdAuCodingType CodecInfoType { get; set; }
		IPlStnCodecInfo CodecInfo { get; }
	}
}
