using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.ClipInfo
{
	public interface ICiAtcDeltaEntry : BluraySharp.Common.IBdPart
	{
		ulong AtcDelta { get; set; }
		BdClipFileRef FollowingClip { get; }
	}
}
