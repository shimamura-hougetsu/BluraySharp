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

		private void Validate(IBdFieldVisitor obj)
		{
			if (object.ReferenceEquals(obj, null))
			{
				throw new ArgumentNullException("obj");
			}
			
			if (object.ReferenceEquals(this.GetAttribute(obj), null))
			{
				//TODO: BdStringField required
				throw new ArgumentException("obj");
			}

			if (obj.Type.GetInterface(typeof(IBdPart).FullName) == null)
			{
				//TODO: cannot treat Field:obj.Name as IBdPart
				throw new ArgumentException("obj");
			}
		}

		public long GetRawLength(IBdFieldVisitor obj)
		{
			this.Validate(obj);

			return this.GetValue(obj).GetRawLength();
		}

		public long SerializeTo(IBdFieldVisitor obj, IBdRawWriteContext context)
		{
			this.Validate(obj);

			IBdPart tField = this.GetValue(obj);
			if (tField != null)
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
			this.Validate(obj);

			IBdPart tField = this.GetValue(obj);
			if (tField != null)
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
