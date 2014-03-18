using BluraySharp.Common.Serializing;
using System;
using System.Linq;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdSubPartFieldIoHelper : IBdRawIoHelper<IBdFieldVisitor>
	{
		private static BdSubPartFieldIoHelper instance = new BdSubPartFieldIoHelper();
		public static BdSubPartFieldIoHelper Instance
		{
			get
			{
				return BdSubPartFieldIoHelper.instance;
			}
		}
		private BdSubPartFieldIoHelper() { }

		private IBdPart GetValue(IBdFieldVisitor obj)
		{
			return obj.Value as IBdPart;
		}

		private BdSubPartFieldAttribute GetAttribute(IBdFieldVisitor obj)
		{
			return obj.Attribute as BdSubPartFieldAttribute;
		}

		private void ValidateArg(IBdFieldVisitor obj)
		{
			if (obj.IsNull())
			{
				throw new ArgumentNullException("obj");
			}
			
			if (this.GetAttribute(obj).IsNull())
			{
				//TODO: BdStringField required
				throw new ArgumentException("obj");
			}

			if (obj.Type.GetInterface(typeof(IBdPart).FullName) == null)
			{
				Type t = obj.Type.GetInterface(typeof(IBdPart).Name);
				//TODO: cannot treat Field:obj.Name as IBdPart
				throw new ArgumentException("obj");
			}
		}

		public long GetRawLength(IBdFieldVisitor obj)
		{
			this.ValidateArg(obj);

			return this.GetValue(obj).GetRawLength();
		}

		public long SerializeTo(IBdFieldVisitor obj, IBdRawWriteContext context)
		{
			this.ValidateArg(obj);

			IBdPart tField = this.GetValue(obj);
			if (!tField.IsNull())
			{
				return tField.SerializeTo(context);
			}
			else
			{
				return 0;
			}
		}

		public long DeserializeFrom(IBdFieldVisitor obj, IBdRawReadContext context)
		{
			this.ValidateArg(obj);

			IBdPart tField = this.GetValue(obj);
			if (! tField.IsNull())
			{
				return tField.DeserializeFrom(context);
			}
			else
			{
				return 0;
			}
		}
	}
}
