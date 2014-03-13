using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BluraySharp.Common
{
	public class BdLangDescriptionAttribute : System.ComponentModel.DescriptionAttribute
	{
		private BdLang language;

		public BdLangDescriptionAttribute(BdLang language)
		{
			this.language = language;
		}

		public override string Description
		{
			get
			{
				return this.language.ToStringLocalized();
			}
		}
	}
}
