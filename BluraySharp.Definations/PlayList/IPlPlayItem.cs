using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public interface IPlPlayItem : IPlPlayItemInfo
	{
		BdUOMask UoMask { get; }

		bool RandomAccessFlag { get; set; }
		IPlStillOptions StillOptions { get; }

		bool IsMultiAngleDifferentAudios { get; set; }
		bool IsMultiAngleOptionsSeamlessChange { get; set; }

		IPlStnTable StnTable { get; }
	}
}
