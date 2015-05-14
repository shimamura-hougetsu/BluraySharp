using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BluraySharp.Common
{
	[TypeConverter(typeof(BdEnumConverter<BdUOFlag>))]
	public enum BdViAspectRatio
	{
		Unknown = 0x0,

		AR_16_9 = 0x03,
	}
}
