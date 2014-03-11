using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnTxCodecInfo : IPlStnCodecInfo
	{
		BdCharacterCodingType CharCode { get; set; }
		BdLang Language { get; set; }
	}
}
