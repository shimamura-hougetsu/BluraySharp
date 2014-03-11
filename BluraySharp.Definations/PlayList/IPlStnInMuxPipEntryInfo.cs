using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public interface IPlStnInMuxPipEntryInfo : IPlStnEntryInfo
	{
		byte SubPathId { get; set; }

		ushort StreamProgId { get; set; }
	}
}
