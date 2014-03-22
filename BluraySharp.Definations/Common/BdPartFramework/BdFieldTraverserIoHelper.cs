/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at Google Code (https://code.google.com/p/bluray-sharp/)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/

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
		private long ForEachFields(IBdFieldTraverser obj, IBdRawIoContext context, RawOperation operation)
		{
			long tLenTotal = 0;

			for (int i = obj.LowerBound; i < obj.UpperBound; ++i)
			{
				obj.Index = i;

				//get skip flag from SkipIndicator of the current field
				bool tIsSkip = false;
				IBdFieldVisitor tIndVisitor = obj.SkipIndicator;
				if (tIndVisitor != null)
				{
					tIsSkip = (this.GetIndicatorValue(tIndVisitor) != 0);
				}

				if (tIsSkip)
				{
					//then Skip.
					continue;
				}

				long tLen = 0;

				//get specified offset of the current field
				tIndVisitor = obj.OffsetIndicator;
				if (!tIndVisitor.IsNull())
				{
					//update offset indicators when operation delegate is null
					if (operation.IsNull())
					{
						this.SetIndicatorValue(tIndVisitor, (ulong)tLenTotal);
					}

					//retrieve offset value
					tLenTotal = (long)this.GetIndicatorValue(tIndVisitor);

					//and move the stream io position to
					if (!context.IsNull())
					{
						context.Position = tLenTotal;
					}
				}

				if (operation.IsNull())
				{
					//update offset indicators when operation delegate is null
					//so count the total length in advance here
					tLen = BdFieldTraverserIoHelper.oprGetLength(obj);
				}

				long tScopeLen = tLen;
				bool tScopeEngaged = false;

				tIndVisitor = obj.LengthIndicator;
				if (!tIndVisitor.IsNull())
				{
					if (operation.IsNull())
					{
						//update
						this.SetIndicatorValue(tIndVisitor, (ulong)tScopeLen);
					}

					tScopeLen = (long)this.GetIndicatorValue(tIndVisitor);

					if (!context.IsNull())
					{
						//enter scope
						context.EnterScope(tScopeLen);
						//and set up a flag
						tScopeEngaged = true;
					}
				}

				try
				{
					if (! operation.IsNull())
					{
						tLen = operation(obj);
					}
					// else tLen == BdFieldTraverserIoHelper.oprGetLength(obj);
				}
				finally
				{
					if (tScopeEngaged)
					{
						context.ExitScope();
						tLen = tScopeLen;
					}
				}

				tLenTotal += tLen;
			}

			return tLenTotal;
		}
		
		private long ForTraverser(IBdFieldTraverser obj, IBdRawIoContext context, RawOperation operation)
		{
			long tTotalLen = 0;
			long tFieldsLen = 0;

			if (operation.IsNull())
			{
				//null value of operation claims an indicator update
				//Get total length of fields, and update fields
				tFieldsLen = this.ForEachFields(obj, null, null);
			}

			long tScopeLen = tFieldsLen;
			bool tScopeEngaged = false;

			IBdFieldVisitor tScopeIndicator = obj.ScopeIndicator;
			if (!tScopeIndicator.IsNull())
			{
				if (operation.IsNull())
				{
					//update bdpart scope indicator
					this.SetIndicatorValue(tScopeIndicator, (ulong)tScopeLen);

					//and count in the indicator 
					tTotalLen += BdFieldTraverserIoHelper.oprGetLength(tScopeIndicator);
				}
				else
				{
					//just perform the operation on scope indicator directly.
					tTotalLen += operation(tScopeIndicator);
				}

				tScopeLen = (long)this.GetIndicatorValue(tScopeIndicator);

				if (!context.IsNull())
				{
					context.EnterScope(tScopeLen);
					tScopeEngaged = true;
				}
			}

			try
			{
				if (!operation.IsNull())
				{
					tFieldsLen = this.ForEachFields(obj, context, operation);
				}
				//else tFieldsLen == this.ForEachFields(obj, null, null);
			}
			finally
			{
				if (tScopeEngaged)
				{
					tFieldsLen = tScopeLen;
					context.ExitScope();
				}
			}

			tTotalLen += tFieldsLen;

			return tTotalLen;
		}

		private void ValidateArg(IBdFieldTraverser obj)
		{
			if (obj.IsNull())
			{
				throw new ArgumentNullException("obj");
			}
		}

		private static IBdRawIoHelper<IBdFieldVisitor> ioHelper =
			BdIoHelperFactory.GetHelper<IBdFieldVisitor>();

		/// <summary>
		/// BdRaw IoOperation : Get RawLength of a field
		/// </summary>
		private static RawOperation oprGetLength = delegate(IBdFieldVisitor xSubObj)
		{
			long tRet = 0;

			if (!xSubObj.Value.IsNull())
			{
				tRet = BdFieldTraverserIoHelper.ioHelper.GetRawLength(xSubObj);
			}

			return tRet;
		};

		/// <summary>
		/// Get total length of BdPart object, meanwhile update all of its indicator fields.
		/// </summary>
		/// <param name="obj">A traverser walking through all fields of a BdPart object</param>
		/// <returns>Total Length</returns>
		public long GetRawLength(IBdFieldTraverser obj)
		{
			this.ValidateArg(obj);

			//specifying a null value for operation to update all indicator fields
			return this.ForTraverser(obj, null, null);
		}

		/// <summary>
		/// Serialize a BdPart object into an IBdRawWriteContext
		/// </summary>
		/// <param name="obj">A traverser walking through all fields of a BdPart object</param>
		/// <param name="context">Destination of Serialization</param>
		/// <returns>Total Length</returns>
		public long SerializeTo(IBdFieldTraverser obj, IBdRawWriteContext context)
		{
			this.ValidateArg(obj);

			RawOperation tOpr = delegate(IBdFieldVisitor xSubObj)
			{
				long xtRet = 0;

				if (!xSubObj.Value.IsNull())
				{
					xtRet = BdFieldTraverserIoHelper.ioHelper.SerializeTo(xSubObj, context);
				}

				return xtRet;
			};
			
			return this.ForTraverser(obj, context, tOpr);
		}

		public long DeserializeFrom(IBdFieldTraverser obj, IBdRawReadContext context)
		{
			this.ValidateArg(obj);

			RawOperation tOpr = delegate(IBdFieldVisitor xSubObj)
			{
				long tRet = 0;

				if (!xSubObj.Value.IsNull())
				{
					tRet = BdFieldTraverserIoHelper.ioHelper.DeserializeFrom(xSubObj, context);
				}

				return tRet;
			};

			return this.ForTraverser(obj, context, tOpr);
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
