using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Architecture;
using BluraySharp.Common.Serializing;
using BluraySharp.Common;

namespace BluraySharp
{
	internal static class ExtensionMethods
	{
		public static T Deserialize<T>(this IBdRawReadContext reader) where T : IBdRawSerializable, new()
		{
			T tObject = new T();

			reader.Deserialize(tObject);
			return tObject;
		}

		public static void SetCount<T>(this IBdList<T> list, int count)
		{
			if (list.Count != count)
			{
				list.Clear();
				for (int i = 0; i < count; ++i)
				{
					list.Add(list.CreateNew());
				}
			}
		}
	}
}
