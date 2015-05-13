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
	}
}
