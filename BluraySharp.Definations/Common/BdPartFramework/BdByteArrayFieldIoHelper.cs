using BluraySharp.Common.Serializing;
using System;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdByteArrayFieldIoHelper : IBdRawIoHelper<IBdField>
	{
		private static BdByteArrayFieldIoHelper instance = new BdByteArrayFieldIoHelper();
		public static BdByteArrayFieldIoHelper Instance
		{
			get
			{
				return BdByteArrayFieldIoHelper.instance;
			}
		}
		private BdByteArrayFieldIoHelper() { }

		private byte[] GetValue(IBdField obj)
		{
			return obj.Value as byte[];
		}

		private BdByteArrayFieldAttribute GetAttribute(IBdField obj)
		{
			return obj.Attribute as BdByteArrayFieldAttribute;
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

			if (obj.Type != typeof(byte[]))
			{
				//TODO: cannot convert between string and Field:obj.Name
				throw new ArgumentException("obj");
			}
		}

		public long GetRawLength(IBdField obj)
		{
			this.Validate(obj);

			byte[] tArray = this.GetValue(obj);
			if (tArray != null)
			{
				return tArray.Length;
			}
			else
			{
				return 0;
			}
		}

		public long SerializeTo(IBdField obj, IBdRawWriteContext context)
		{
			this.Validate(obj);

			byte[] tArray = this.GetValue(obj);
			if (tArray != null)
			{
				context.Serialize(tArray);
				return tArray.Length;
			}
			else
			{
				return 0;
			}
		}

		public long DeserializeFrom(IBdField obj, IBdRawReadContext context)
		{
			this.Validate(obj);

			byte[] tArray = this.GetValue(obj);
			if (tArray != null)
			{
				context.Deserialize(tArray);
				return tArray.Length;
			}
			else
			{
				return 0;
			}
		}
	}
}
