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
		private long ForEachIn(IBdFieldTraverser obj, IBdRawIoContext context, RawOperation operation)
		{
			long tLenTotal = 0;

			for (obj.Index = obj.LowerBound;
				obj.Index < obj.UpperBound;
				++obj.Index)
			{
				bool tIsSkip = false;
				IBdFieldVisitor tIndVistor = obj.SkipIndicator;
				if (tIndVistor != null)
				{
					tIsSkip = (this.GetIndicatorValue(tIndVistor) != 0);
				}

				long tLen = 0, tScopeLen = 0;
				if(! tIsSkip)
				{
					tIndVistor = obj.OffsetIndicator;
					if (!tIndVistor.RefEquals(null))
					{
						tLenTotal = (long)this.GetIndicatorValue(tIndVistor);
						if (!context.RefEquals(null))
						{
							context.Position = tLenTotal;
						}
					}

					tIndVistor = obj.LengthIndicator;
					if(! tIndVistor.RefEquals(null))
					{
						tScopeLen = (long)this.GetIndicatorValue(tIndVistor);
						if (!context.RefEquals(null))
						{
							context.EnterScope(tScopeLen);
						}
					}
					try
					{
						if (!operation.RefEquals(null))
						{
							tLen = operation(obj);
						}
						else
						{
							tLen = this.ioHelper.GetRawLength(obj);
						}
					}
					finally
					{
						if (!tIndVistor.RefEquals(null))
						{
							if (!context.RefEquals(null))
							{
								context.ExitScope();
							}
							tLen = tScopeLen;
						}
					}
				}

				tLenTotal += tLen;
			}

			return tLenTotal;
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

			RawOperation tOpr = delegate(IBdFieldVisitor xSubObj)
			{				
				long tRet = 0;

				if (!xSubObj.Value.RefEquals(null))
				{
					tRet = this.ioHelper.GetRawLength(xSubObj);
				}
			
				return tRet;
			};

			return this.ForEachIn(obj, null, tOpr);
		}

		public long SerializeTo(IBdFieldTraverser obj, IBdRawWriteContext context)
		{
			this.Validate(obj);

			this.ForEachIn(obj, null, null);

			RawOperation tOpr = delegate(IBdFieldVisitor xSubObj)
			{
				long tRet = 0;

				if (!xSubObj.Value.RefEquals(null))
				{
					tRet = this.ioHelper.SerializeTo(xSubObj, context);
				}

				return tRet;
			};

			return this.ForEachIn(obj, context, tOpr);
		}

		public long DeserializeFrom(IBdFieldTraverser obj, IBdRawReadContext context)
		{

			this.ForEachIn(obj, null, null);

			RawOperation tOpr = delegate(IBdFieldVisitor xSubObj)
			{
				long tRet = 0;

				if (!xSubObj.Value.RefEquals(null))
				{
					tRet = this.ioHelper.DeserializeFrom(xSubObj, context);
				}

				return tRet;
			};

			return this.ForEachIn(obj, context, tOpr);
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
