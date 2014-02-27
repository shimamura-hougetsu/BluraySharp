using BluraySharp.FileSystem;

namespace BluraySharp.ClipInfo
{
	[BdArrayEntry("CLIPINF", "clpi", 100000, true)]
	public interface IClipInfo : IBdfsArrayEntry
	{
	}
}
