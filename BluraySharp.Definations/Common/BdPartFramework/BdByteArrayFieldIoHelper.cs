using BluraySharp.Common.Serializing;
using System;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdByteArrayFieldIoHelper : IBdRawIoHelper<IBdFieldVisitor>
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

		private byte[] GetValue(IBdFieldVisitor obj)
		{
			return obj.Value as byte[];
		}

		private BdByteArrayFieldAttribute GetAttribute(IBdFieldVisitor obj)
		{
			return obj.Attribute as BdByteArrayFieldAttribute;
		}

		private void Validate(IBdFieldVisitor obj)
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

			if (obj.Type != typeof(byte[]))
			{
				//TODO: cannot convert between string and Field:obj.Name
				throw new ArgumentException("obj");
			}
		}

		public long GetRawLength(IBdFieldVisitor obj)
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

		public long SerializeTo(IBdFieldVisitor obj, IBdRawWriteContext context)
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

		public long DeserializeFrom(IBdFieldVisitor obj, IBdRawReadContext context)
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
