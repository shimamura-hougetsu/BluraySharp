using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnSaRecord : IPlStnRecord
	{
		BdSaCodingType CodingType { get; set; }
		BdAuPresentationType Presentation { get; set; }
		BdAuSampleRate SampleFrequency { get; set; }
		BdLang Language { get; set; }

		IList<byte> PrimaryAudioRef { get; }
	}
}
