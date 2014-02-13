using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnSecViRecord : IPlStnRecord
	{
		BdViCodingType CodingType { get; set; }
		BdViFormat VideoFormat { get; set; }
		BdViFrameRate FrameRate { get; set; }

		IList<byte> SecondaryAudioRef { get; }
		IList<byte> PipSubtitleRef { get; }
	}
}
