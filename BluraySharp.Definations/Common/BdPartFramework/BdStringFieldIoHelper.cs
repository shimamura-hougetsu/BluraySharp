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

			if (obj.Type != typeof(string))
			{
				//TODO: cannot convert between string and Field:obj.Name
				throw new ArgumentException("obj");
			}
		}

		public long GetRawLength(IBdFieldVisitor obj)
		{
			this.ValidateArg(obj);

			return this.GetAttribute(obj).ByteCount;
		}

		public long SerializeTo(IBdFieldVisitor obj, IBdRawWriteContext context)
		{
			this.ValidateArg(obj);

			BdStringFieldAttribute tAttrib = this.GetAttribute(obj);
			context.Serialize(this.GetValue(obj), tAttrib.ByteCount, tAttrib.Encoding);

			return tAttrib.ByteCount;
		}

		public long DeserializeFrom(IBdFieldVisitor obj, IBdRawReadContext context)
		{
			this.ValidateArg(obj);

			BdStringFieldAttribute tAttrib = this.GetAttribute(obj);
			obj.Value = context.Deserialize(tAttrib.ByteCount, tAttrib.Encoding);

			return tAttrib.ByteCount;
		}
	}
}
