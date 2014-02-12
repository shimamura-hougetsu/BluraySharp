using System;
using BluraySharp.Architecture;
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
