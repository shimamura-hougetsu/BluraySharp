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

using System.Collections.Generic;

namespace BluraySharp.Common.BdPartFramework
{
	internal static class BdIoHelperFactory
	{
		private static Dictionary<string, object> helpers = new Dictionary<string, object>();

		public static IBdRawIoHelper<T> GetHelper<T>()
		{
			return BdIoHelperFactory.helpers[typeof(T).FullName] as IBdRawIoHelper<T>;
		}

		public static void RegisterHelper<T>(IBdRawIoHelper<T> helper)
		{
			BdIoHelperFactory.helpers[typeof(T).FullName] = helper;
		}
	}
}
