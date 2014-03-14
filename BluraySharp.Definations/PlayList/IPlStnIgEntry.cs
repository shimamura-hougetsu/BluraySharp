using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnIgEntry : IPlStnEntry
	{
		BdIgCodingType AttrInfoType { get; set; }
		IPlStnAttrInfo AttrInfo { get; }
	}
}
