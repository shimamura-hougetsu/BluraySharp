using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnSaEntry : IPlStnEntry
	{
		BdSaCodingType AttrInfoType { get; set; }
		IPlStnAttrInfo AttrInfo { get; }

		IBdList<byte> PrimaryAudioIdRef { get; }
	}
}
