using BluraySharp.Common.Serializing;
using System;
using System.Reflection;

namespace BluraySharp.Common.BdPartRawIoHelper
{
	public abstract class BdPart : IBdPart
	{
		private static IBdRawIoHelper<IBdFieldSeeker> ioHelp =
			BdFieldIoHelperFactory.FieldSetIoHelper;

		private IBdFieldSeeker fieldSeeker;
		public BdPart()
		{
			Type tSeekerType = typeof(BdFieldSeeker<>).MakeGenericType(this.GetType());
			ConstructorInfo tCtor = tSeekerType.GetConstructor(Type.EmptyTypes);
			this.fieldSeeker = (IBdFieldSeeker) tCtor.Invoke(new object[0]);
		}

		public long SerializeTo(IBdRawWriteContext context)
		{
			return BdPart.ioHelp.SerializeTo(this.fieldSeeker, context);
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			return BdPart.ioHelp.DeserializeFrom(this.fieldSeeker, context);
		}

		public long RawLength
		{
			get
			{
				return BdPart.ioHelp.GetRawLength(this.fieldSeeker);
			}
		}

		public abstract override string ToString();
	}
}
