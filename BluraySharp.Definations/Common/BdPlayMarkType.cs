using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common
{
	public enum BdPlayMarkType : byte
	{
		Unknown = 0x00,

		PmEntryMark = 0x01,
		PmLinkPoint = 0x02,
	}
}
