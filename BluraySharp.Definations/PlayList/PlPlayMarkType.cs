using BluraySharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<PlPlayMarkType>))]
	public enum PlPlayMarkType : byte
	{
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown = 0x00,

		PmEntryMark = 0x01,
		PmLinkPoint = 0x02,
	}
}
