using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common.BdPartRawIoHelper
{
	internal abstract class BdFieldAttribute : Attribute
	{
		public BdFieldType FieldType { get; private set; }

		public BdFieldAttribute(BdFieldType type)
		{
			this.FieldType = type;
		}
	}
}
