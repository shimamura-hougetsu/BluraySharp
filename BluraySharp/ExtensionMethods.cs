using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Properties;
using System.Globalization;

namespace BluraySharp
{
	public static class ExtensionMethods
	{
		public static string ToStringLocalized(this Enum obj)
		{
			List<string> tDescDict = new List<string>();
			string tEnumDescName = string.Format("Enum_{0}_{1}", obj.GetType().Name, Enum.GetName(obj.GetType(), obj));

			return Resources.ResourceManager.GetString(tEnumDescName);
		}

		public static bool GetBit(this ulong obj, byte index)
		{
			return ((obj >> index) & 0x01) == 1;
		}

		public static T SetBit<T>(this T obj, byte index)  where T: struct, IConvertible
		{
			ulong tMask = GetMask<T>(index, 1);

			return (T)(object)(obj.ToUInt64(new NumberFormatInfo()) | tMask);
		}

		public static T UnsetBit<T>(this T obj, byte index) where T : struct, IConvertible
		{
			ulong tMask = GetMask<T>(index, 1);

			return (T)(object)(obj.ToUInt64(new NumberFormatInfo()) & ~tMask);
		}

		public static ulong GetMask<T>(byte index, byte length) where T: struct
		{
			switch (typeof(T).FullName)
			{
				case "System.Byte":
					VerifyIndexRange(sizeof(byte), index, length);
					break;
				case "System.UInt16":
					VerifyIndexRange(sizeof(ushort), index, length);
					break;
				case "System.UInt32":
					VerifyIndexRange(sizeof(uint), index, length);
					break;
				case "System.UInt64":
					VerifyIndexRange(sizeof(ulong), index, length);
					break;
				default:
					throw new ArgumentException("uintType");
			}

			ulong tMask = 0xFFFFFFFFFFFFFFFF;
			return ((~(tMask << length)) << index);
		}

		private static void VerifyIndexRange(int size, byte index, byte length)
		{
			if (index > size)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			else if (index + length > size)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			else if (length < 1)
			{
				throw new ArgumentException("length");
			}
		}
	}
}
