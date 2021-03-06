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

using BluraySharp.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		/// <param name="culture">Culture value</param>
		/// <returns>Localized description</returns>
		public static string ToStringLocalized(this Enum obj, CultureInfo culture)
		{
			List<string> tDescDict = new List<string>();
			string tEnumName = Enum.GetName(obj.GetType(), obj);
			string tEnumDesc = null;

			if (!culture.Equals(CultureInfo.InvariantCulture))
			{
				tEnumDesc = string.Format("Enum_{0}_{1}", obj.GetType().Name, tEnumName);
				tEnumDesc = Properties.Resources.ResourceManager.GetString(tEnumDesc, culture);
			}

			if (string.IsNullOrEmpty(tEnumDesc))
			{
				tEnumDesc = tEnumName;
			}

			return tEnumDesc;

		}

		public static string ToStringLocalized(this Enum obj)
		{
			return obj.ToStringLocalized(CultureInfo.CurrentUICulture);
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

		private static Dictionary<BdViFrameRate, int> bdViFrameRateToIntegerTable =
			new Dictionary<BdViFrameRate, int>()
			{
				{BdViFrameRate.Vi23, 24 },
				{BdViFrameRate.Vi24, 24 },
				{BdViFrameRate.Vi25, 25 },
				{BdViFrameRate.Vi29, 30 },
				{BdViFrameRate.Vi50, 50 },
				{BdViFrameRate.Vi59, 60 }
			};
		public static int ToInteger(this BdViFrameRate value)
		{
			return ExtensionMethods.bdViFrameRateToIntegerTable[value];
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

		public static bool RefEql(this object obj1, object obj2)
		{
			return object.ReferenceEquals(obj1, obj2);
		}

		public static bool IsNull(this object obj)
		{
			return obj.RefEql(null);
		}

		public static bool IsNullOrWhiteSpace(this string str)
		{
			return string.IsNullOrWhiteSpace(str);
		}

		public static bool IsNullOrEmpty(this string str)
		{
			return string.IsNullOrEmpty(str);
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
					@"([A-Z][a-z]{2})\b"
					);
				if (tMatch.Success)
				{
					tDictionary[iLang] = tMatch.Captures[0].Value.ToLower();
				}
				else
				{
					tDictionary[iLang] = "\0\0\0";
				}
			}

			return tDictionary;
		}

		private static Dictionary<BdLang, CultureInfo> cultureInfoTable =
			ExtensionMethods.CreateCultureInfoTable();
		private static Dictionary<BdLang, CultureInfo> CreateCultureInfoTable()
		{
			List<CultureInfo> tCultureInfoes = new List<CultureInfo>(CultureInfo.GetCultures(CultureTypes.NeutralCultures));
			tCultureInfoes.Sort((x1, x2) => x1.Name.Length - x2.Name.Length);

			Dictionary<BdLang, CultureInfo> tDictionary = new Dictionary<BdLang, CultureInfo>();

			foreach (BdLang iBdLang in ExtensionMethods.langCodeTable.Keys)
			{
				CultureInfo tCultureInfo = tCultureInfoes.FirstOrDefault(
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

		internal static BdLang ToBdLang(this string langCode)
		{
			Match tMatches = Regex.Match(langCode, @"^([a-z]{3})\b");
			if (!tMatches.Success)
			{
				return BdLang.Ivl;
			}
			else
			{
				string tIsoLangCode = tMatches.Captures[0].Value;
				return ExtensionMethods.langCodeTable.FirstOrDefault(xPair => xPair.Value == tIsoLangCode).Key;
			}
		}

		public static string ToStringLocalized(this BdLang lang)
		{
			return lang.ToStringLocalized(CultureInfo.CurrentUICulture);
		}

		public static string ToStringLocalized(this BdLang lang, CultureInfo culture)
		{
			CultureInfo tCultureInfo = ExtensionMethods.cultureInfoTable[lang];
			string tIsoLangCode = lang.ToIsoLangCode();

			if (culture.Equals(CultureInfo.InvariantCulture))
			{
				return tIsoLangCode;
			}
			else
			{
				string tDisplayName;
				if (tCultureInfo.IsNull())
				{
					tDisplayName = (lang as Enum).ToStringLocalized(culture);
				}
				else
				{
					tDisplayName = tCultureInfo.NativeName;
				}

				return string.Format("{0} ({1})", tIsoLangCode, tDisplayName);
			}
		}

		[Conditional("DEBUG")]
		public static void AssertFalse(this bool condition)
		{
			Debug.Assert(!condition);
		}

		[Conditional("DEBUG")]
		public static void AssertTrue(this bool condition)
		{
			Debug.Assert(condition);
		}

		[Conditional("DEBUG")]
		public static void AssertNotNull(this object obj)
		{
			Debug.Assert(!obj.IsNull());
		}
	}
}
