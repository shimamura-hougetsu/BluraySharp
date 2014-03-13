using BluraySharp.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace BluraySharp
{
	/// <summary>
	/// Extension methods for all BDMV basic classes.
	/// </summary>
	public static class ExtensionMethods
	{
		/// <summary>
		/// Get localized friendly name for enumeration values
		/// </summary>
		/// <param name="obj">An enumeration value</param>
		/// <returns>Localized description</returns>
		public static string ToStringLocalized(this Enum obj)
		{
			List<string> tDescDict = new List<string>();
			string tEnumName = Enum.GetName(obj.GetType(), obj);
			string tEnumDesc = string.Format("Enum_{0}_{1}", obj.GetType().Name, tEnumName);

			tEnumDesc = Properties.Resources.ResourceManager.GetString(tEnumDesc);
			if (string.IsNullOrEmpty(tEnumDesc))
			{
				tEnumDesc = tEnumName;
			}

			return tEnumDesc;
		}

		/// <summary>
		/// Get raw-size of a BDMV object
		/// </summary>
		/// <param name="obj">BDMV object</param>
		/// <returns>Bytes occupied by the object</returns>
		public static long GetRawLength(this IBdPart obj)
		{
			if (object.ReferenceEquals(obj, null))
			{
				return 0;
			}
			else
			{
				return obj.RawLength;
			}
		}

		/// <summary>
		/// Convert a ulong value to byte, ushort or uint, by specifying outputSize.
		/// </summary>
		/// <param name="value">Source ulong value</param>
		/// <param name="outputSize">Expected size of output value</param>
		/// <returns>Output value</returns>
		public static object ToUInt(this ulong value, BdIntSize outputSize)
		{
			switch (outputSize)
			{
				case BdIntSize.U8:
					return Convert.ToByte(value);
				case BdIntSize.U16:
					return Convert.ToUInt16(value);
				case BdIntSize.U32:
					return Convert.ToUInt32(value);
				case BdIntSize.U64:
					return value;
				default:
					throw new ArgumentException("outputSize");
			}
		}

		private static Dictionary<BdViFrameRate, double> bdViFrameRateToDoubleTable =
			new Dictionary<BdViFrameRate, double>()
			{
				{BdViFrameRate.Vi23, 24000/1001.0 },
				{BdViFrameRate.Vi24, 24000/1000.0 },
				{BdViFrameRate.Vi25, 25000/1000.0 },
				{BdViFrameRate.Vi29, 30000/1001.0 },
				{BdViFrameRate.Vi50, 50000/1000.0 },
				{BdViFrameRate.Vi59, 60000/1001.0 }
			};
		public static double ToDouble(this BdViFrameRate value)
		{
			return ExtensionMethods.bdViFrameRateToDoubleTable[value];
		}


		private static Dictionary<BdAuSampleRate, double> bdAuSampleRateToDoubleTable =
			new Dictionary<BdAuSampleRate, double>()
			{
				{BdAuSampleRate.Au48, 48000.0 },
				{BdAuSampleRate.Au96, 96000.0 },
				{BdAuSampleRate.Au192, 192000.0 },
				{BdAuSampleRate.Au48_96, 48000.0 },
				{BdAuSampleRate.Au48_192, 48000.0 },
			};
		public static double ToDouble(this BdAuSampleRate value)
		{
			return ExtensionMethods.bdAuSampleRateToDoubleTable[value];
		}

		public static bool RefEquals(this object obj1, object obj2)
		{
			return object.ReferenceEquals(obj1, obj2);
		}

		public static bool IsNull(this object obj)
		{
			return obj.RefEquals(null);
		}


		private static readonly Dictionary<BdLang, string> langCodeTable =
			ExtensionMethods.CreateLangCodeTable();

		private static Dictionary<BdLang, string> CreateLangCodeTable()
		{
			Dictionary<BdLang, string> tDictionary = new Dictionary<BdLang,string>();
			foreach(BdLang iLang in Enum.GetValues(typeof(BdLang)))
			{
				Match tMatch = Regex.Match(
					Enum.GetName(typeof(BdLang), iLang),
					@"LANG_(\w{3})"
					);
				if(tMatch.Success)
				{
					tDictionary[iLang] = tMatch.Groups[1].Value.ToLower();
				}
			}

			return tDictionary;
		}

		private static Dictionary<BdLang, CultureInfo> cultureInfoTable =
			ExtensionMethods.CreateCultureInfoTable();
		private static Dictionary<BdLang, CultureInfo> CreateCultureInfoTable()
		{
			CultureInfo[] tCultureInfos = CultureInfo.GetCultures(CultureTypes.NeutralCultures);
			Dictionary<BdLang, CultureInfo> tDictionary = new Dictionary<BdLang, CultureInfo>();

			foreach (BdLang iBdLang in ExtensionMethods.langCodeTable.Keys)
			{
				CultureInfo tCultureInfo = tCultureInfos.FirstOrDefault(
					xCultureInfo =>
						xCultureInfo.ThreeLetterISOLanguageName == ExtensionMethods.langCodeTable[iBdLang]
					);
				tDictionary.Add(iBdLang, tCultureInfo);
			}

			return tDictionary;
		}

		public static string ToIsoLangCode(this BdLang lang)
		{
			if (ExtensionMethods.langCodeTable.ContainsKey(lang))
			{
				return ExtensionMethods.langCodeTable[lang];
			}
			else
			{
				throw new KeyNotFoundException("lang");
			}
		}

		public static BdLang ToBdLang(this BluraySharp.Common.BdStandardPart.BdLangCode isoLangCode)
		{
			return ExtensionMethods.langCodeTable.First(xPair => xPair.Value == isoLangCode.IsoLangCode).Key;
		}

		public static string ToStringLocalized(this BdLang lang)
		{
			CultureInfo tCultureInfo = ExtensionMethods.cultureInfoTable[lang];
			if (tCultureInfo.IsNull())
			{
				return (lang as Enum).ToStringLocalized();
			}
			else
			{
				return tCultureInfo.NativeName;
			}
		}
	}
}
