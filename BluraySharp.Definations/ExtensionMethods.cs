using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Properties;
using System.Globalization;

namespace BluraySharp
{
	/// <summary>
	/// Extension methods for all BDAV basic classes.
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

			tEnumDesc = Resources.ResourceManager.GetString(tEnumDesc);
			if (string.IsNullOrEmpty(tEnumDesc))
			{
				tEnumDesc = tEnumName;
			}

			return tEnumDesc;
		}

		/// <summary>
		/// Get raw-size of a BDAV object
		/// </summary>
		/// <param name="obj">BDAV object</param>
		/// <returns>Bytes occupying by the object</returns>
		public static long GetRawLength(this IBdObject obj)
		{
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return obj.RawLength;
			}
		}
	}
}
