using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public interface IPlPlayItem : IPlPlayItemInfo
	{
		BdUOMask UoMask { get; }

		bool RandomAccessProhibited { get; set; }
		IPlStillInfo StillInfo { get; }

		IPlStnTable StnTable { get; }
	}
}
