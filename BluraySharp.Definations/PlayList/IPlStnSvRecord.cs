using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnSvEntry : IPlStnEntry
	{
		BdViCodingType CodecInfoType { get; set; }
		IPlStnCodecInfo CodecInfo { get; }

		IBdList<byte> SecondaryAudioIdRef { get; }
		IBdList<byte> PipSubtitleIdRef { get; }
	}
}
