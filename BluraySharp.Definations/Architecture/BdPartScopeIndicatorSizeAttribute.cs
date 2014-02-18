using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace BluraySharp.Architecture
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
	public class BdPartScopeIndicatorSizeAttribute : Attribute
	{
		public BdIntSize IndicatorSize { get; private set; }

		public BdPartScopeIndicatorSizeAttribute(BdIntSize indicatorSize)
		{
			this.IndicatorSize = indicatorSize;
		}
	}
}
