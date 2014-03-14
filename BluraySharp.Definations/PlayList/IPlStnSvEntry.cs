using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnSvEntry : IPlStnEntry
	{
		BdViCodingType AttrInfoType { get; set; }
		IPlStnAttrInfo AttrInfo { get; }

		IBdList<byte> SecondaryAudioIdRef { get; }
		IBdList<byte> PipSubtitleIdRef { get; }
	}
}
