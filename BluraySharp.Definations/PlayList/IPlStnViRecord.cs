using System;
using BluraySharp.Serializing;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnViRecord : IPlStnRecord
	{
		BdViCodingType CodingType { get; set; }
		BdViFormat VideoFormat { get; set; }
		BdViFrameRate FrameRate { get; set; }
	}
}
