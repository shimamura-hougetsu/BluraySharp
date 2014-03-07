using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdPartLengthIndicatorAttribute : Attribute
	{
		public string Indicator { get; private set; }
		public BdIntSize Size { get; private set; }

		public BdPartLengthIndicatorAttribute(string indicator, BdIntSize size)
		{
			this.Indicator = indicator;
			this.Size = size;
		}
	}
}
