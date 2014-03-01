using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common.BdPartRawIoHelper
{
	internal class BdFieldIoHelper : IBdRawIoHelper<IBdField>
	{
		private static BdFieldIoHelper instance = new BdFieldIoHelper();
		public static BdFieldIoHelper Instance
		{
			get
			{
				return BdFieldIoHelper.instance;
			}
		}

		private BdFieldIoHelper() { }

		private BdFieldType GuessFieldType(Type type)
		{
			//TODO: guess field type.
			return BdFieldType.Unknown;
		}

		private IBdRawIoHelper<IBdField> CreateHelper(IBdField fieldInfo)
		{
			BdFieldType tFtype = fieldInfo.Attribute.FieldType;
			if (tFtype == BdFieldType.Unknown)
			{
				tFtype = this.GuessFieldType(fieldInfo.Type);
			}

			//current field is root of a loop of fields;
			if (fieldInfo.Type.GetInterface(typeof(IBdList).FullName) != null)
			{
				return BdLoopFieldIoHelper.Instance;
			}
			else
			{
				switch (tFtype)
				{
					case BdFieldType.ByteArray:
						return BdByteArrayFieldIoHelper.Instance;

					case BdFieldType.SubPart:
						return BdSubPartFieldIoHelper.Instance;

					case BdFieldType.String:
						return BdStringFieldIoHelper.Instance;

					case BdFieldType.UInt:
						return BdUIntFieldIoHelper.Instance;

					default:
						//TODO: Unkonwn field type.
						throw new ApplicationException();
				}
			}
		}

		public long GetRawLength(IBdField obj)
		{
			IBdRawIoHelper<IBdField> tIoHelper = this.CreateHelper(obj);
			return tIoHelper.GetRawLength(obj);
		}

		public long SerializeTo(IBdField obj, Serializing.IBdRawWriteContext context)
		{
			IBdRawIoHelper<IBdField> tIoHelper = this.CreateHelper(obj);
			return tIoHelper.SerializeTo(obj, context);
		}

		public long DeserializeFrom(IBdField obj, Serializing.IBdRawReadContext context)
		{
			IBdRawIoHelper<IBdField> tIoHelper = this.CreateHelper(obj);
			return tIoHelper.DeserializeFrom(obj, context);
		}
	}
}
