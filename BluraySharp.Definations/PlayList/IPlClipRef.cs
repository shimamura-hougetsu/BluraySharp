using BluraySharp.Common;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public interface IPlClipRef : IBdPart
	{
		BdClipFileRef ClipFileRef { get; }
		byte StcIdRef { get; set; }
	}
}
