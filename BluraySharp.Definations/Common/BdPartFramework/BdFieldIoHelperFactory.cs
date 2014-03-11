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
