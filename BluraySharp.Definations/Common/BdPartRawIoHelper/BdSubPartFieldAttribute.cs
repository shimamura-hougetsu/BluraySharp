using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common.BdPartRawIoHelper
{
	internal class BdSubPartFieldAttribute : BdFieldAttribute
	{
		public BdSubPartFieldAttribute()
			: base(BdFieldType.SubPart)
		{
		}
	}
}
