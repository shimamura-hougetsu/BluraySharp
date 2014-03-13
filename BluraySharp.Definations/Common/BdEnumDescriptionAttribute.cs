using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BluraySharp.Common
{
	public class BdEnumDescriptionAttribute : DescriptionAttribute
	{
		private Enum enumValue;

		public BdEnumDescriptionAttribute(object enumValue)
		{
			Enum tEnumValue = enumValue as Enum;
			if (tEnumValue == null)
			{
				throw new ArgumentException("enumValue");
			}

			this.enumValue = tEnumValue;
		}

		public override string Description
		{
			get
			{
				return this.enumValue.ToStringLocalized();
			}
		}
	}
}
