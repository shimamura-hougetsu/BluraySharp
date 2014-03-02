using BluraySharp.Common.Serializing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdLoopFieldIoHelper : IBdRawIoHelper<IBdField>
	{
		private static BdLoopFieldIoHelper instance = new BdLoopFieldIoHelper();
		public static BdLoopFieldIoHelper Instance
		{
			get
			{
				return BdLoopFieldIoHelper.instance;
			}
		}

		private BdLoopFieldIoHelper() { }

		private void Validate(IBdField obj)
		{
			if(object.ReferenceEquals(obj, null))
			{
				throw new ArgumentNullException("obj");
			}

			if (object.ReferenceEquals(obj.Type, null))
			{
				//TODO: Unknown field type
				throw new ArgumentException("obj");
			}

			if(obj.Type.GetInterface(typeof(IBdList).FullName) == null)
			{
				//TODO: accept IBdList fields only
				throw new ArgumentException("obj");
			}
		}

		private IBdRawIoHelper<IBdFieldSeeker> ioHelper =
			BdIoHelperFactory.GetHelper<IBdFieldSeeker>();

		public long GetRawLength(IBdField obj)
		{
			this.Validate(obj);

			BdLoopFieldSeeker tSeeker = new BdLoopFieldSeeker(obj);
			return this.ioHelper.GetRawLength(tSeeker);
		}

		public long SerializeTo(IBdField obj, IBdRawWriteContext context)
		{
			this.Validate(obj);

			BdLoopFieldSeeker tSeeker = new BdLoopFieldSeeker(obj);
			return this.ioHelper.SerializeTo(tSeeker, context);
		}

		public long DeserializeFrom(IBdField obj, IBdRawReadContext context)
		{
			this.Validate(obj);
			
			BdLoopFieldSeeker tSeeker = new BdLoopFieldSeeker(obj);
			return this.ioHelper.DeserializeFrom(tSeeker, context);
		}
	}
}
