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
		private long ForEachFields(IBdFieldTraverser obj, IBdRawIoContext context, RawOperation operation, bool isUpdatingIndicators)
		{
			long tLenTotal = 0;

			for (int i = obj.LowerBound; i < obj.UpperBound; ++i)
			{
				obj.Index = i;

				bool tIsSkip = false;
				IBdFieldVisitor tIndVisitor = obj.SkipIndicator;
				if (tIndVisitor != null)
				{
					tIsSkip = (this.GetIndicatorValue(tIndVisitor) != 0);
				}

				long tLen = 0;
				if (!tIsSkip)
				{
					tIndVisitor = obj.OffsetIndicator;
					if (!tIndVisitor.IsNull())
					{
						if (isUpdatingIndicators)
						{
							this.SetIndicatorValue(tIndVisitor, (ulong)tLenTotal);
						}

						tLenTotal = (long)this.GetIndicatorValue(tIndVisitor);

						if (!context.IsNull())
						{
							context.Position = tLenTotal;
						}
					}

					tLen = BdFieldTraverserIoHelper.ioHelper.GetRawLength(obj);
					long tScopeLen = 0;
					bool tScopeEngaged = false;

					tIndVisitor = obj.LengthIndicator;
					if (!tIndVisitor.IsNull())
					{
						if (isUpdatingIndicators)
						{
							tScopeLen = tLen;
							this.SetIndicatorValue(tIndVisitor, (ulong)tScopeLen);
						}

						tScopeLen = (long)this.GetIndicatorValue(tIndVisitor);
						tScopeEngaged = true;

						if (!context.IsNull())
						{
							context.EnterScope(tScopeLen);
						}
					}

					try
					{
						if (!operation.IsNull())
						{
							tLen = operation(obj);
						}
					}
					finally
					{
						if (tScopeEngaged)
						{
							if (!context.IsNull())
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
		
		private long ForTraverser(IBdFieldTraverser obj, IBdRawIoContext context, RawOperation operation, bool isUpdatingIndicators)
		{
			long tTotalLen = 0;
			long tFieldsLen = 0;

			IBdFieldVisitor tScopeIndicator = obj.ScopeIndicator;
			long tScopeLen = 0;
			bool tScopeEngaged = false;

			if (isUpdatingIndicators)
			{
				tScopeLen = this.ForEachFields(obj, null, BdFieldTraverserIoHelper.oprGetLength, true);
			}

			if (!tScopeIndicator.IsNull())
			{
				tScopeEngaged = true;

				if (isUpdatingIndicators)
				{
					this.SetIndicatorValue(tScopeIndicator, (ulong)tScopeLen);
				}

				if (!operation.IsNull())
				{
					tTotalLen += operation(tScopeIndicator);
				}
				else
				{
					tTotalLen += BdFieldTraverserIoHelper.oprGetLength(tScopeIndicator);
				}

				tScopeLen = (long)this.GetIndicatorValue(tScopeIndicator);

				if (!context.IsNull())
				{
					context.EnterScope(tScopeLen);
				}
			}

			try
			{
				if (!operation.IsNull())
				{
					tFieldsLen = this.ForEachFields(obj, context, operation, false);
				}
				else
				{
					tFieldsLen = tScopeLen;
				}
			}
			finally
			{
				if (tScopeEngaged)
				{
					tFieldsLen = tScopeLen;
					if (!context.IsNull())
					{
						context.ExitScope();
					}
				}
			}

			tTotalLen += tFieldsLen;

			return tTotalLen;
		}

		private void Validate(IBdFieldTraverser obj)
		{
			if (obj.IsNull())
			{
				throw new ArgumentNullException("obj");
			}
		}

		private static IBdRawIoHelper<IBdFieldVisitor> ioHelper =
			BdIoHelperFactory.GetHelper<IBdFieldVisitor>();

		private static RawOperation oprGetLength = delegate(IBdFieldVisitor xSubObj)
		{
			long tRet = 0;

			if (!xSubObj.Value.IsNull())
			{
				tRet = BdFieldTraverserIoHelper.ioHelper.GetRawLength(xSubObj);
			}

			return tRet;
		};


		public long GetRawLength(IBdFieldTraverser obj)
		{
			this.Validate(obj);

			return this.ForTraverser(obj, null, null, true);
		}

		public long SerializeTo(IBdFieldTraverser obj, IBdRawWriteContext context)
		{
			this.Validate(obj);

			RawOperation tOpr = delegate(IBdFieldVisitor xSubObj)
			{
				long tRet = 0;

				if (!xSubObj.Value.IsNull())
				{
					tRet = BdFieldTraverserIoHelper.ioHelper.SerializeTo(xSubObj, context);
				}

				return tRet;
			};

			return this.ForTraverser(obj, context, tOpr, true);
		}

		public long DeserializeFrom(IBdFieldTraverser obj, IBdRawReadContext context)
		{
			this.Validate(obj);

			RawOperation tOpr = delegate(IBdFieldVisitor xSubObj)
			{
				long tRet = 0;

				if (!xSubObj.Value.IsNull())
				{
					tRet = BdFieldTraverserIoHelper.ioHelper.DeserializeFrom(xSubObj, context);
				}

				return tRet;
			};

			return this.ForTraverser(obj, context, tOpr, false);
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
