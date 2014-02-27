using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common.BdPartDescribing
{
	internal class BdUIntFieldFieldAttribute : BdFieldAttribute
	{
		public BdIntSize Size { get; private set; }
		public BdUIntFieldFieldAttribute(BdIntSize size)
			:base(BdFieldType.UInt)
		{
			this.Size = size;
		}
	}
}
