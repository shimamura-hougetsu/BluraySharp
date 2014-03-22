/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at Google Code (https://code.google.com/p/bluray-sharp/)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/

using BluraySharp.Common;
using BluraySharp.Common.Serializing;

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

		public static int SetCount<T>(this IBdList<T> list, int count)
		{
			if (list.Count != count)
			{
				list.Clear();
				for (int i = 0; i < count; ++i)
				{
					list.Add(list.CreateNew());
				}
			}

			return list.Count;
		}
	}
}
