using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public interface IPlStnInMuxPipStreamEntryFields : IPlStnStreamEntry
	{
		byte SubPathId { get; set; }

		ushort StreamProgId { get; set; }
	}
}
