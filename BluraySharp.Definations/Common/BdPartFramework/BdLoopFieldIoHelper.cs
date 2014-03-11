﻿using BluraySharp.Common.Serializing;
using System;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdLoopFieldIoHelper : IBdRawIoHelper<IBdFieldVisitor>
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

		private void Validate(IBdFieldVisitor obj)
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

		private IBdRawIoHelper<IBdFieldTraverser> ioHelper =
			BdIoHelperFactory.GetHelper<IBdFieldTraverser>();

		public long GetRawLength(IBdFieldVisitor obj)
		{
			this.Validate(obj);

			BdLoopFieldTraverser tSeeker = new BdLoopFieldTraverser(obj);
			return this.ioHelper.GetRawLength(tSeeker);
		}

		public long SerializeTo(IBdFieldVisitor obj, IBdRawWriteContext context)
		{
			this.Validate(obj);

			BdLoopFieldTraverser tSeeker = new BdLoopFieldTraverser(obj);
			return this.ioHelper.SerializeTo(tSeeker, context);
		}

		public long DeserializeFrom(IBdFieldVisitor obj, IBdRawReadContext context)
		{
			this.Validate(obj);
			
			BdLoopFieldTraverser tSeeker = new BdLoopFieldTraverser(obj);
			return this.ioHelper.DeserializeFrom(tSeeker, context);
		}
	}
}