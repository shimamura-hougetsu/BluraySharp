using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnViEntry : IPlStnEntry
	{
		BdViCodingType CodecInfoType { get; set; }
		IPlStnCodecInfo CodecInfo { get; }
	}
}
