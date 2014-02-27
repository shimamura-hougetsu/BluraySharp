﻿using BluraySharp.Common;
using BluraySharp.Serializing;
using System;
using System.Collections.Generic;

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
	}
}
