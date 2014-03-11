using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common;
using BluraySharp.Common.Serializing;

namespace BluraySharp.PlayList
{
	public interface IPlStnAuCodecInfo : IPlStnCodecInfo
	{
		BdAuPresentationType Presentation { get; set; }
		BdAuSampleRate SampleFrequency { get; set; }
		BdLang Language { get; set; }
	}
}
