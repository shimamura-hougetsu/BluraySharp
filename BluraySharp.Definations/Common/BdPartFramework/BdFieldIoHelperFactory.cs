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

using System;
using System.Collections.Generic;

namespace BluraySharp.Common.BdPartFramework
{
	internal static class BdIoHelperFactory
	{
		private static Dictionary<Type, object> helpers = new Dictionary<Type, object>();

		static BdIoHelperFactory()
		{
			BdIoHelperFactory.RegisterHelper(BdFieldIoHelper.Instance);
			BdIoHelperFactory.RegisterHelper(BdFieldTraverserIoHelper.Instance);
		}

		public static IBdRawIoHelper<T> GetHelper<T>()
		{
			return BdIoHelperFactory.helpers[typeof(T)] as IBdRawIoHelper<T>;
		}

		private static void RegisterHelper<T>(IBdRawIoHelper<T> helper)
		{
			BdIoHelperFactory.helpers[typeof(T)] = helper;
		}
	}
}
