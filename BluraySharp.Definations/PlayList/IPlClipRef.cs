using System;
using BluraySharp.Common.Serializing;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlClipRef : IBdPart
	{
		IPlClipFileRef ClipFileRef { get; }
		byte StcIdRef { get; set; }
	}
}
