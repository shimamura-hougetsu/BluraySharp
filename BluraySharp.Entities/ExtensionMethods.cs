using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Architecture;

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
	}
}
