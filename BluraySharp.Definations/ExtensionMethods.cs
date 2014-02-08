using System;
using System.Collections.Generic;
using BluraySharp.Architecture;

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

			tEnumDesc = Properties.Resources.ResourceManager.GetString(tEnumDesc);
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
	}
}
