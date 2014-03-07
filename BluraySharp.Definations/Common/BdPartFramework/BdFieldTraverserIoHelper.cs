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
		private long ForEachIn(IBdFieldTraverser obj, IBdRawIoContext context, RawOperation operation, bool isUpdatingIndicators)
		{
			long tSeekerScopeLen = 0;
			bool tSeekerScopeEngaged = false;

			//TODO: seeker scope

			long tLenTotal = 0;

			for (obj.Index = obj.LowerBound;
				obj.Index < obj.UpperBound;
				++obj.Index)
			{
				bool tIsSkip = false;
				IBdFieldVisitor tIndVisitor = obj.SkipIndicator;
				if (tIndVisitor != null)
				{
					tIsSkip = (this.GetIndicatorValue(tIndVisitor) != 0);
				}

				long tLen = 0;
				if(! tIsSkip)
				{
					tIndVisitor = obj.OffsetIndicator;
					if (!tIndVisitor.RefEquals(null))
					{
						if (isUpdatingIndicators)
						{
							this.SetIndicatorValue(tIndVisitor, (ulong)tLenTotal);
						}

						tLenTotal = (long)this.GetIndicatorValue(tIndVisitor);

						if (!context.RefEquals(null))
						{
							context.Position = tLenTotal;
						}
					}

					tLen = this.ioHelper.GetRawLength(obj);
					long tScopeLen = 0;
					bool tScopeEngaged = false;

					tIndVisitor = obj.LengthIndicator;
					if(! tIndVisitor.RefEquals(null))
					{
						if (isUpdatingIndicators)
						{
							tScopeLen = tLen;
							this.SetIndicatorValue(tIndVisitor, (ulong) tScopeLen);
						}

						tScopeLen = (long)this.GetIndicatorValue(tIndVisitor);
						tScopeEngaged = true;

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
					}
					finally
					{
						if (tScopeEngaged)
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

			//this.ForEachIn(obj, null, null, true);

			RawOperation tOpr = delegate(IBdFieldVisitor xSubObj)
			{				
				long tRet = 0;

				if (!xSubObj.Value.RefEquals(null))
				{
					tRet = this.ioHelper.GetRawLength(xSubObj);
				}
			
				return tRet;
			};

			return this.ForEachIn(obj, null, tOpr, true);
		}

		public long SerializeTo(IBdFieldTraverser obj, IBdRawWriteContext context)
		{
			this.Validate(obj);

			this.ForEachIn(obj, null, null, true);

			RawOperation tOpr = delegate(IBdFieldVisitor xSubObj)
			{
				long tRet = 0;

				if (!xSubObj.Value.RefEquals(null))
				{
					tRet = this.ioHelper.SerializeTo(xSubObj, context);
				}

				return tRet;
			};

			return this.ForEachIn(obj, context, tOpr, false);
		}

		public long DeserializeFrom(IBdFieldTraverser obj, IBdRawReadContext context)
		{
			this.Validate(obj);

			RawOperation tOpr = delegate(IBdFieldVisitor xSubObj)
			{
				long tRet = 0;

				if (!xSubObj.Value.RefEquals(null))
				{
					tRet = this.ioHelper.DeserializeFrom(xSubObj, context);
				}

				return tRet;
			};

			return this.ForEachIn(obj, context, tOpr, false);
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
