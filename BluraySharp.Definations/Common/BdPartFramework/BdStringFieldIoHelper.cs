﻿using BluraySharp.Common.Serializing;
using System;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdStringFieldIoHelper : IBdRawIoHelper<IBdFieldVisitor>
	{
		private static BdStringFieldIoHelper instance = new BdStringFieldIoHelper();
		public static BdStringFieldIoHelper Instance
		{
			get
			{
				return BdStringFieldIoHelper.instance;
			}
		}
		private BdStringFieldIoHelper() { }

		private string GetValue(IBdFieldVisitor obj)
		{
			return (string) obj.Value;
		}

		private BdStringFieldAttribute GetAttribute(IBdFieldVisitor obj)
		{
			return obj.Attribute as BdStringFieldAttribute;
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

			if (obj.Type != typeof(string))
			{
				//TODO: cannot convert between string and Field:obj.Name
				throw new ArgumentException("obj");
			}
		}

		public long GetRawLength(IBdFieldVisitor obj)
		{
			this.Validate(obj);

			return this.GetAttribute(obj).ByteCount;
		}

		public long SerializeTo(IBdFieldVisitor obj, IBdRawWriteContext context)
		{
			this.Validate(obj);

			BdStringFieldAttribute tAttrib = this.GetAttribute(obj);
			context.Serialize(this.GetValue(obj), tAttrib.ByteCount, tAttrib.Encoding);

			return tAttrib.ByteCount;
		}

		public long DeserializeFrom(IBdFieldVisitor obj, IBdRawReadContext context)
		{
			this.Validate(obj);

			BdStringFieldAttribute tAttrib = this.GetAttribute(obj);
			obj.Value = context.Deserialize(tAttrib.ByteCount, tAttrib.Encoding);

			return tAttrib.ByteCount;
		}
	}
}
