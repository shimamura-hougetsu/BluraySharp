using BluraySharp.Common;
using BluraySharp.Common.BdStandardPart;


namespace BluraySharp.PlayList
{
	public interface IPlPlayItemInfo : IBdPart
	{
		BdTime InTime { get; set; }
		BdTime OutTime { get; set; }

		BdConnectionCondition ConnectionCondition { get; set; }
		IBdList<IPlClipRef> ClipList { get; }
	}
}
