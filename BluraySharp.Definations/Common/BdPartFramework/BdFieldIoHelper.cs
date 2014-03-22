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

using System;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdFieldIoHelper : IBdRawIoHelper<IBdFieldVisitor>
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

		private IBdRawIoHelper<IBdFieldVisitor> CreateHelper(IBdFieldVisitor fieldInfo)
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

		public long GetRawLength(IBdFieldVisitor obj)
		{
			IBdRawIoHelper<IBdFieldVisitor> tIoHelper = this.CreateHelper(obj);
			return tIoHelper.GetRawLength(obj);
		}

		public long SerializeTo(IBdFieldVisitor obj, Serializing.IBdRawWriteContext context)
		{
			IBdRawIoHelper<IBdFieldVisitor> tIoHelper = this.CreateHelper(obj);
			return tIoHelper.SerializeTo(obj, context);
		}

		public long DeserializeFrom(IBdFieldVisitor obj, Serializing.IBdRawReadContext context)
		{
			IBdRawIoHelper<IBdFieldVisitor> tIoHelper = this.CreateHelper(obj);
			return tIoHelper.DeserializeFrom(obj, context);
		}
	}
}
