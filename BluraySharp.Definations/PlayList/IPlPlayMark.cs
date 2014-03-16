using BluraySharp.Common;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public interface IPlPlayMark : IBdPart
	{
		PlPlayMarkType MarkType { get; set; }
		ushort PlayItemSId { get; set; }
		BdTime TimeStamp { get; set; }
		ushort StreamProgId { get; set; }
		uint Duration { get; set; }
	}
}
