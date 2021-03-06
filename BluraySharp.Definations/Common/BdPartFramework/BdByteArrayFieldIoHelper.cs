/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at BitBucket (https://bitbucket.org/subelf/bluraysharp)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/

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

		private void ValidateArg(IBdFieldVisitor obj)
		{
			if (obj.IsNull())
			{
				throw new ArgumentNullException("obj");
			}
			
			if (this.GetAttribute(obj).IsNull())
			{
				//TODO: BdByteArrayField required
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
			this.ValidateArg(obj);

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
			this.ValidateArg(obj);

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
			this.ValidateArg(obj);

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
