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
	}
}
