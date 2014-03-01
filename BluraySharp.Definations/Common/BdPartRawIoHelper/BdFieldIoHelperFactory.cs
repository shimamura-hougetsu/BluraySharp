using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common.BdPartRawIoHelper
{
	internal static class BdFieldIoHelperFactory
	{
		public static IBdRawIoHelper<IBdField> GenericFieldIoHelper
		{
			get
			{
				return BdLoopFieldIoHelper.Instance;
			}
		}

		public static IBdRawIoHelper<IBdFieldSeeker> FieldSetIoHelper
		{
			get
			{
				return BdFieldSeekerIoHelper.Instance;
			}
		}
	}
}
