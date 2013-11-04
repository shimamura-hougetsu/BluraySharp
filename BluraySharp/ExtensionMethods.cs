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
			string tEnumName = Enum.GetName(obj.GetType(), obj);
			string tEnumDesc = string.Format("Enum_{0}_{1}", obj.GetType().Name, tEnumName);

			tEnumDesc = Resources.ResourceManager.GetString(tEnumDesc);
			if (string.IsNullOrEmpty(tEnumDesc))
			{
				tEnumDesc = tEnumName;
			}

			return tEnumDesc;
		}


		private static NumberFormatInfo _Formatter = new NumberFormatInfo();

		public static T GetBits<T>(this T obj, byte index, byte length) where T : struct, IConvertible
		{
			Converter<ulong, T> tConv = VerifyTemplateArg<T>(index, length);

			ulong tValue = ~(0xFFFFFFFFFFFFFFFF << length);
			tValue &= (obj.ToUInt64(_Formatter) >> index);

			return tConv(tValue);
		}

		public static T SetBits<T>(this T obj, byte index, byte length, T value) where T : struct, IConvertible
		{
			Converter<ulong, T> tConv = VerifyTemplateArg<T>(index, length);

			ulong tValue1 = ~(0xFFFFFFFFFFFFFFFF << length);
			ulong tValue2 = ~(tValue1 << index);

			tValue2 &= obj.ToUInt64(_Formatter);
			tValue1 &= value.ToUInt64(_Formatter);

			tValue2 |= (tValue1 << index);

			return tConv(tValue2);
		}

		private static Converter<ulong, T> VerifyTemplateArg<T>(byte index, byte length) where T : struct
		{
			switch (typeof(T).FullName)
			{
				case "System.Byte":
					VerifyIndexRange(sizeof(byte), index, length);
					return (x => (T)(object)(byte)x);
				case "System.UInt16":
					VerifyIndexRange(sizeof(ushort), index, length);
					return (x => (T)(object)(ushort)x);
				case "System.UInt32":
					VerifyIndexRange(sizeof(uint), index, length);
					return (x => (T)(object)(uint)x);
				case "System.UInt64":
					VerifyIndexRange(sizeof(ulong), index, length);
					return (x => (T)(object) x);
				default:
					throw new ArgumentException("uintType");
			}
		}

		private static void VerifyIndexRange(int size, byte index, byte length)
		{
			size <<= 3;

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
