using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdUIntFieldAttribute : BdFieldAttribute
	{
		public BdIntSize Size { get; private set; }
		public BdUIntFieldAttribute(BdIntSize size)
			:base(BdFieldType.UInt)
		{
			this.Size = size;
		}
	}
}
