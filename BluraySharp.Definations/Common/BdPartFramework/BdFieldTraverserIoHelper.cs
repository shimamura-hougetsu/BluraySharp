using BluraySharp.Common.Serializing;
using System;
using System.Diagnostics;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdFieldTraverserIoHelper : IBdRawIoHelper<IBdFieldTraverser>
	{
		private static BdFieldTraverserIoHelper instance = new BdFieldTraverserIoHelper();
		public static BdFieldTraverserIoHelper Instance
		{
			get
			{
				return BdFieldTraverserIoHelper.instance;
			}
		}

		private BdFieldTraverserIoHelper() { }

		private delegate long RawOperation(IBdFieldVisitor obj);
		private long ForEachIn(IBdFieldTraverser obj, RawOperation operation)
		{
			long tLength = 0;

			for (obj.Index = obj.LowerBound;
				obj.Index < obj.UpperBound;
				++obj.Index)
			{
				tLength += operation(obj);
			}

			return tLength;
		}

		private void Validate(IBdFieldTraverser obj)
		{
			if (object.ReferenceEquals(obj, null))
			{
				throw new ArgumentNullException("obj");
			}
		}

		private IBdRawIoHelper<IBdFieldVisitor> ioHelper =
			BdIoHelperFactory.GetHelper<IBdFieldVisitor>();

		public long GetRawLength(IBdFieldTraverser obj)
		{
			this.Validate(obj);

			long tPos = 0;

			RawOperation tOpr = delegate(IBdFieldVisitor xSubObj)
			{				
				long tRet = 0;

				if (!xSubObj.Value.RefEquals(null))
				{
					IBdFieldVisitor tIndicator = xSubObj.OffsetIndicator;
					if (tIndicator != null)
					{
						this.SetIndicatorValue(tIndicator, (ulong)tPos);
					}

					tRet = this.ioHelper.GetRawLength(xSubObj);
					tPos += tRet;

					tIndicator = xSubObj.LengthIndicator;
					if (tIndicator != null)
					{
						this.SetIndicatorValue(tIndicator, (ulong) tRet);
					}

				}
			
				return tRet;
			};

			return this.ForEachIn(obj, tOpr);
		}

		public long SerializeTo(IBdFieldTraverser obj, IBdRawWriteContext context)
		{
			this.Validate(obj);

			long tScopeLen = this.GetRawLength(obj);

			//TODO: serialize length indicator

			RawOperation tOpr = delegate(IBdFieldVisitor xSubObj)
			{
				long tRet = 0;

				if (!xSubObj.Value.RefEquals(null))
				{
					IBdFieldVisitor tIndicator = xSubObj.OffsetIndicator;
					if (tIndicator != null)
					{
						long tOffset = (long)this.GetIndicatorValue(tIndicator);
						if (tOffset != 0)
						{
							context.Position = tOffset;
						}
					}
					
					tIndicator = xSubObj.LengthIndicator;
					if (tIndicator != null)
					{
						long tLength = (long)this.GetIndicatorValue(tIndicator);
						context.EnterScope(tLength);
					}
					try
					{
						tRet = this.ioHelper.SerializeTo(xSubObj, context);
					}
					finally
					{
						if (tIndicator != null)
						{
							context.ExitScope();
						}
					}
				}

				return tRet;
			};

			return this.ForEachIn(obj, tOpr);
		}

		public long DeserializeFrom(IBdFieldTraverser obj, IBdRawReadContext context)
		{
			this.Validate(obj);

			RawOperation tOpr = delegate(IBdFieldVisitor xSubObj)
			{
				long tRet = 0;

				IBdFieldVisitor tIndicator = xSubObj.OffsetIndicator;
				if (tIndicator != null)
				{
					long tOffset = (long)this.GetIndicatorValue(tIndicator);
					if (tOffset != 0)
					{
						context.Position = tOffset;
					}
				}

				tIndicator = xSubObj.LengthIndicator;
				if (tIndicator != null)
				{
					long tLength = (long)this.GetIndicatorValue(tIndicator);
					context.EnterScope(tLength);
				}
				try
				{
					tRet = this.ioHelper.DeserializeFrom(xSubObj, context);
				}
				finally
				{
					if (tIndicator != null)
					{
						context.ExitScope();
					}
				}

				return tRet;
			};

			return this.ForEachIn(obj, tOpr);
		}

		private ulong GetIndicatorValue(IBdFieldVisitor indicator)
		{
			return Convert.ToUInt64(indicator.Value);
		}

		private void SetIndicatorValue(IBdFieldVisitor indicator, ulong value)
		{
			ulong tValue = this.GetIndicatorValue(indicator);

			if (tValue != value)
			{
				indicator.Value = Convert.ChangeType(value, indicator.Type);
			}
		}
	}
}
