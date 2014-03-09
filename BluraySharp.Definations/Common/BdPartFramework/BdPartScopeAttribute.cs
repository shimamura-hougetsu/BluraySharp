using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdPartScopeAttribute : Attribute
	{
		public BdIntSize Size { get; private set; }
		public string IndicatorField { get; set; }

		public BdPartScopeAttribute(BdIntSize size)
		{
			this.Size = size;
		}
	}
}
