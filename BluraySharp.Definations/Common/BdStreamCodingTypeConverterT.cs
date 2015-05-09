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
using System.Reflection;

namespace BluraySharp.Common
{
	internal class BdStreamCodingTypeConverter<T> : EnumConverter
	{
		private Dictionary<string, Dictionary<string, T>> enumDict =
			new Dictionary<string, Dictionary<string, T>>();

		private bool isBdEnum = true;

		public BdStreamCodingTypeConverter()
			: base(typeof(T))
		{
			Type tType = typeof(T);
			this.isBdEnum &= tType.BaseType.Equals(typeof(Enum));
			this.isBdEnum &= Enum.GetUnderlyingType(tType).Equals(typeof(byte));
			this.isBdEnum &= tType.Assembly.Equals(Assembly.GetExecutingAssembly());
			this.isBdEnum &= !tType.IsDefined(typeof(FlagsAttribute), false);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (this.isBdEnum && value.GetType().Equals(typeof(string)))
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

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (this.isBdEnum && destinationType.Equals(typeof(string)))
			{
				var tDict = this.GetNameDictLocalized(culture);

				T tValue = (T)value;

				string tEnumName = tDict.FirstOrDefault(xPair => xPair.Value.Equals(tValue)).Key;
				if (!tEnumName.IsNull())
				{
					return tEnumName;
				}
				else
				{
					BdStreamCodingType tCodingTypeValue = (BdStreamCodingType) Convert.ToByte(tValue);
					tEnumName = tCodingTypeValue.ToStringLocalized(culture);
					tDict.Add(tEnumName, tValue);
					if (!tEnumName.IsNull())
					{
						return tEnumName;
					}
				}
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}

		private Dictionary<string, T> GetNameDictLocalized(CultureInfo culture)
		{
			if (this.enumDict.ContainsKey(culture.Name))
			{
				return this.enumDict[culture.Name];
			}
			else
			{
				Dictionary<string, T> tDict = new Dictionary<string, T>();

				return this.enumDict[culture.Name] = tDict;
			}
		}
	}
}
