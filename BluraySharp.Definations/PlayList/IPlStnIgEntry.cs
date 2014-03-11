using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnIgEntry : IPlStnEntry
	{
		BdIgCodingType CodecInfoType { get; set; }
		IPlStnCodecInfo CodecInfo { get; }
	}
}
