using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public interface IPlPlayItem : IPlPlayItemInfo
	{
		BdUOMask UoMask { get; }

		bool RandomAccessProhibited { get; set; }
		IPlStillOptions StillOptions { get; }

		IPlStnTable StnTable { get; }
	}
}
