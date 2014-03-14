using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnTxAttrInfo : IPlStnAttrInfo
	{
		BdCharacterCodingType CharCode { get; set; }
		BdLang Language { get; set; }
	}
}
