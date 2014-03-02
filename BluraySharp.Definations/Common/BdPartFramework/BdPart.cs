using BluraySharp.Common.Serializing;
using System;
using System.Reflection;

namespace BluraySharp.Common.BdPartFramework
{
	public abstract class BdPart : IBdPart
	{
		private static IBdRawIoHelper<IBdFieldSeeker> ioHelp = BdPart.InitializeIoHelpers();

		private IBdFieldSeeker fieldSeeker;

		private static IBdRawIoHelper<IBdFieldSeeker> InitializeIoHelpers()
		{
			BdIoHelperFactory.RegisterHelper(BdFieldIoHelper.Instance);
			BdIoHelperFactory.RegisterHelper(BdFieldSeekerIoHelper.Instance);

			return BdIoHelperFactory.GetHelper<IBdFieldSeeker>();
		}

		public BdPart()
		{
			Type tSeekerType = typeof(BdFieldSeeker<>).MakeGenericType(this.GetType());
			ConstructorInfo tCtor = tSeekerType.GetConstructor(new Type[] { this.GetType() });
			this.fieldSeeker = (IBdFieldSeeker)tCtor.Invoke(new object[] { this });
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
