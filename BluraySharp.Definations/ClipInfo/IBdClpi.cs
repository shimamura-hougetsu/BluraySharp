using BluraySharp.Common;

namespace BluraySharp.ClipInfo
{
	[BdmvArrayEntry("CLIPINF", "clpi", 100000, true)]
	public interface IBdClpi : IBdmvArrayEntry
	{
		string ClpiMark { get; }
		string ClpiVer { get; set; }

		ICiClipInfo ClipInfo { get; }
	}
}
