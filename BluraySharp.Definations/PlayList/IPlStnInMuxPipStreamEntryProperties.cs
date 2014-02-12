using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public interface IPlStnInMuxPipStreamEntryProperties : IPlStnStreamEntry
	{
		byte SubPathId { get; set; }
	}
}
