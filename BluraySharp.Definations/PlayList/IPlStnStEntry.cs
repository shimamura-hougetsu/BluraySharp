using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnStEntry : IPlStnEntry
	{
		BdStCodingType CodecInfoType { get; set; }
		IPlStnCodecInfo CodecInfo { get; }
	}
}
