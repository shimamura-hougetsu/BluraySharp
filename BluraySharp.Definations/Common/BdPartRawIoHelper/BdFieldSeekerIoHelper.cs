﻿using BluraySharp.Common.Serializing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BluraySharp.Common.BdPartRawIoHelper
{
	internal class BdFieldSeekerIoHelper : IBdRawIoHelper<IBdFieldSeeker>
	{
		private static BdFieldSeekerIoHelper instance = new BdFieldSeekerIoHelper();
		public static BdFieldSeekerIoHelper Instance
		{
			get
			{
				return BdFieldSeekerIoHelper.instance;
			}
		}

		private BdFieldSeekerIoHelper() { }

		private delegate long RawOperation(long offset, IBdFieldSeeker obj);
		private long ForEachIn(IBdFieldSeeker obj, RawOperation operation)
		{
			long tLength = 0;

			for (obj.Index = obj.LowerBound;
				obj.Index < obj.UpperBound;
				++obj.Index)
			{
				tLength = operation(tLength, obj);
			}

			return tLength;
		}

		private void Validate(IBdFieldSeeker obj)
		{
			if (object.ReferenceEquals(obj, null))
			{
				throw new ArgumentNullException("obj");
			}
		}

		private IBdRawIoHelper<IBdField> ioHelper = 
			BdFieldIoHelperFactory.GenericFieldIoHelper;

		public long GetRawLength(IBdFieldSeeker obj)
		{
			this.Validate(obj);

			RawOperation tOpr = delegate(long xOfs, IBdFieldSeeker xSubObj)
			{
				if (xSubObj.IsOffsetSpecified)
				{
					xSubObj.Offset = (ulong) xOfs;
				}
			
				return xOfs + this.ioHelper.GetRawLength(xSubObj);
			};

			return this.ForEachIn(obj, tOpr);
		}

		public long SerializeTo(IBdFieldSeeker obj, IBdRawWriteContext context)
		{
			this.Validate(obj);

			long tLen = this.GetRawLength(obj);

			context.EnterScope(tLen);
			try
			{
				RawOperation tOpr = delegate(long xOfs, IBdFieldSeeker xSubObj)
				{
					if (xSubObj.IsOffsetSpecified)
					{
						Debug.Assert(context.Position == (long)xSubObj.Offset);
						Debug.Assert(xOfs == context.Position);
					}

					IBdRawIoHelper<IBdField> tHelper = this.ioHelper;
					tHelper.SerializeTo(xSubObj, context);

					return xOfs + tHelper.GetRawLength(xSubObj);
				};

				return this.ForEachIn(obj, tOpr);
			}
			finally
			{
				context.ExitScope();
			}
		}

		public long DeserializeFrom(IBdFieldSeeker obj, IBdRawReadContext context)
		{
			this.Validate(obj);

			long tLen = this.GetRawLength(obj);

			context.EnterScope(tLen);
			try
			{
				RawOperation tOpr = delegate(long xOfs, IBdFieldSeeker xSubObj)
				{
					if (xSubObj.IsOffsetSpecified)
					{
						context.Position = xOfs = (long)xSubObj.Offset;
					}

					IBdRawIoHelper<IBdField> tHelper = this.ioHelper;
					tHelper.DeserializeFrom(xSubObj, context);

					return xOfs + tHelper.GetRawLength(xSubObj);
				};

				return this.ForEachIn(obj, tOpr);
			}
			finally
			{
				context.ExitScope();
			}
		}
	}
}
