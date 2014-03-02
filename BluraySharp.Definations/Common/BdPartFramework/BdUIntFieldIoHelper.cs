using BluraySharp.Common.Serializing;
using System;
using System.Linq;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdUIntFieldIoHelper : IBdRawIoHelper<IBdField>
	{
		private static BdUIntFieldIoHelper instance = new BdUIntFieldIoHelper();
		public static BdUIntFieldIoHelper Instance
		{
			get
			{
				return BdUIntFieldIoHelper.instance;
			}
		}
		private BdUIntFieldIoHelper() { }

		private ulong GetValue(IBdField obj)
		{
			return Convert.ToUInt64(obj.Value);
		}

		private void SetValue(IBdField obj, ulong value)
		{
			obj.Value = Convert.ChangeType(value, obj.Type);
		}

		private BdUIntFieldAttribute GetAttribute(IBdField obj)
		{
			return obj.Attribute as BdUIntFieldAttribute;
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

			Type tType = obj.Type;
			if (!tType.IsValueType || tType.GetInterface(typeof(IConvertible).FullName) == null) 
			{
				//TODO: cannot convert between ulong and Field:obj.Name
				throw new ArgumentException("obj");
			}
		}
		private BdIntSize GetSize(IBdField obj)
		{
			BdUIntFieldAttribute tAttrib = this.GetAttribute(obj);
			return tAttrib.Size;
		}

		public long GetRawLength(IBdField obj)
		{
			this.Validate(obj);

			return (long) this.GetSize(obj);
		}


		public long SerializeTo(IBdField obj, IBdRawWriteContext context)
		{
			this.Validate(obj);

			BdIntSize tSize = this.GetSize(obj);

			context.Serialize(this.GetValue(obj), this.GetAttribute(obj).Size);
			return (long)tSize;
		}

		public long DeserializeFrom(IBdField obj, IBdRawReadContext context)
		{
			this.Validate(obj);

			BdIntSize tSize = this.GetSize(obj);
			this.SetValue(obj, context.Deserialize(this.GetAttribute(obj).Size));

			return (long)tSize;
		}
	}
}
