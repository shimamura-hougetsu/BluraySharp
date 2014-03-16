using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BluraySharp.Common
{
	internal class BdLangConverter : TypeConverter
	{
		Dictionary<string, Dictionary<string, BdLang>> enumDict =
			new Dictionary<string, Dictionary<string, BdLang>>();
		Array langValues = Enum.GetValues(typeof(BdLang));
		
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			if (context.PropertyDescriptor.PropertyType.Equals(typeof(BdLang)))
			{
				return true;
			}

			return base.GetPropertiesSupported(context);
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new StandardValuesCollection(langValues);
		}

		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return true;
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if(sourceType.Equals(typeof(string)))
			{
				return true;
			}

			return base.CanConvertFrom(context, sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType.Equals(typeof(string)))
			{
				return true;
			}

			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
		{
			if (value.GetType().Equals(typeof(string)))
			{
				var tDict = this.GetNameDictLocalized(culture);
				var tEnum = tDict.FirstOrDefault(xPair => xPair.Key.Equals(value)).Value;
				if (!tEnum.IsNull())
				{
					return tEnum;
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
