using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public interface IPlStnPlayItemEntryInfo : IPlStnEntryInfo
	{
		ushort StreamProgId { get; set; }
	}
}
