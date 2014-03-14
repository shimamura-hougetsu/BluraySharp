using System;
using BluraySharp.Common.Serializing;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnViAttrInfo : IPlStnAttrInfo
	{
		BdViFormat VideoFormat { get; set; }
		BdViFrameRate FrameRate { get; set; }
	}
}
