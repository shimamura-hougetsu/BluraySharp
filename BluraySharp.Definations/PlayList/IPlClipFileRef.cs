using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlClipFileRef : IBdPart
	{
		string ClipCodec { get; set; }
		uint ClipId { get; set; }
	}
}
