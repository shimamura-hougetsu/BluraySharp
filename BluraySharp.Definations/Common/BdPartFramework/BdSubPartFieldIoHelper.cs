using BluraySharp.Common.Serializing;
using System;
using System.Linq;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdSubPartFieldIoHelper : IBdRawIoHelper<IBdField>
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

		private IBdPart GetValue(IBdField obj)
		{
			return obj.Value as IBdPart;
		}

		private BdSubPartFieldAttribute GetAttribute(IBdField obj)
		{
			return obj.Attribute as BdSubPartFieldAttribute;
		}

		private void Validate(IBdField obj)
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

		public long GetRawLength(IBdField obj)
		{
			this.Validate(obj);

			return this.GetValue(obj).GetRawLength();
		}

		public long SerializeTo(IBdField obj, IBdRawWriteContext context)
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

		public long DeserializeFrom(IBdField obj, IBdRawReadContext context)
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
