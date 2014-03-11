using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnSaEntry : IPlStnEntry
	{
		BdSaCodingType CodecInfoType { get; set; }
		IPlStnCodecInfo CodecInfo { get; }

		IBdList<byte> PrimaryAudioIdRef { get; }
	}
}
