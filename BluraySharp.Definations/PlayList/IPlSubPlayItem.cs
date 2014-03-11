using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public interface IPlSubPlayItem : IPlPlayItemInfo
	{
		ushort SyncPlayItemId { get; set; }
		BdTime SyncPlayTime { get; set; }
	}
}
