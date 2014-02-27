using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common.BdPartDescribing
{
	internal abstract class BdFieldAttribute : Attribute
	{
		public BdFieldType Type { get; private set; }

		public BdFieldAttribute(BdFieldType type)
		{
			this.Type = type;
		}
	}
}
