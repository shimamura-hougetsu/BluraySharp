using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnSecAuRecord : IPlStnRecord
	{
		BdSaCodingType CodingType { get; set; }
		BdAuPresentationType PresentationType { get; set; }
		BdAuSampleRate SampleRate { get; set; }
		BdLang Language { get; set; }

		IList<byte> PrimaryAudioRef { get; }
	}
}
