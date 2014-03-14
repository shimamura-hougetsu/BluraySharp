using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnAuEntry : IPlStnEntry
	{
		BdAuCodingType AttrInfoType { get; set; }
		IPlStnAttrInfo AttrInfo { get; }
	}
}
