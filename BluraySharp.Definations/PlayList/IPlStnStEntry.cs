using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnStEntry : IPlStnEntry
	{
		BdStCodingType AttrInfoType { get; set; }
		IPlStnAttrInfo AttrInfo { get; }
	}
}
