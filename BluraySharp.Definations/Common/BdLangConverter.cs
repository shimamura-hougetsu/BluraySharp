/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at BitBucket (https://bitbucket.org/subelf/bluraysharp)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace BluraySharp.Common
{
	internal class BdLangConverter : EnumConverter
	{
		Dictionary<string, Dictionary<string, BdLang>> enumDict =
			new Dictionary<string, Dictionary<string, BdLang>>();

		public BdLangConverter()
			: base(typeof(BdLang)) { }
		
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return false;
		}
		
		public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
		{
			if (value.GetType().Equals(typeof(string)))
			{
				var tDict = this.GetNameDictLocalized(culture);
				try
				{
					return tDict.First(xPair => xPair.Key.Equals(value)).Value;
				}
				catch (InvalidOperationException){}

				var tValue = (value as string);
				if (!string.IsNullOrEmpty(tValue))
				{
					return tValue.Trim().ToBdLang();
				}
			}

			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType.Equals(typeof(string)))
			{
				var tDict = this.GetNameDictLocalized(culture);

				BdLang tValue = (BdLang)value;

				string tEnumName = tDict.FirstOrDefault(xPair => xPair.Value.Equals(tValue)).Key;
				if (!tEnumName.IsNull())
				{
					return tEnumName;
				}
				else
				{
					tEnumName = tValue.ToStringLocalized(culture);
					tDict.Add(tEnumName, tValue);
					if (!tEnumName.IsNull())
					{
						return tEnumName;
					}
				}
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}

		private Dictionary<string, BdLang> GetNameDictLocalized(CultureInfo culture)
		{
			if (this.enumDict.ContainsKey(culture.Name))
			{
				return this.enumDict[culture.Name];
			}
			else
			{
				Dictionary<string, BdLang> tDict = new Dictionary<string, BdLang>();

				return this.enumDict[culture.Name] = tDict;
			}
		}
	}
}
