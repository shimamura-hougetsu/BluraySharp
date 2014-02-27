using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common.BdPartDescribing
{
	internal class BdByteArrayFieldAttribute : BdFieldAttribute
	{
		public BdByteArrayFieldAttribute()
			:base(BdFieldType.ByteArray)
		{
		}
	}
}
