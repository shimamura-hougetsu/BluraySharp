using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnViEntry : IPlStnEntry
	{
		BdViCodingType AttrInfoType { get; set; }
		IPlStnAttrInfo AttrInfo { get; }
	}
}
