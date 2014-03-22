/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at Google Code (https://code.google.com/p/bluray-sharp/)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/

using BluraySharp.Common.Serializing;
using System;
using System.Linq;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdUIntFieldIoHelper : IBdRawIoHelper<IBdFieldVisitor>
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

		private ulong GetValue(IBdFieldVisitor obj)
		{
			if (obj.IsNull())
			{
				throw new ArgumentNullException();
			}

			return Convert.ToUInt64(obj.Value);
		}

		private void SetValue(IBdFieldVisitor obj, ulong value)
		{
			if(obj.IsNull())
			{
				throw new ArgumentNullException();
			}
			
			Type tIntType = obj.Type;
			if (obj.Type.BaseType.Equals(typeof(Enum)))
			{
				tIntType = Enum.GetUnderlyingType(obj.Type);
			}

			obj.Value = Convert.ChangeType(value, tIntType);
		}

		private BdUIntFieldAttribute GetAttribute(IBdFieldVisitor obj)
		{
			return obj.Attribute as BdUIntFieldAttribute;
		}

		private void ValidateArg(IBdFieldVisitor obj)
		{
			if (obj.IsNull())
			{
				throw new ArgumentNullException("obj");
			}
			
			if (this.GetAttribute(obj).IsNull())
			{
				//TODO: BdUIntField required
				throw new ArgumentException("obj");
			}

			Type tType = obj.Type;
			if (!tType.IsValueType || tType.GetInterface(typeof(IConvertible).FullName) == null) 
			{
				//TODO: cannot convert between ulong and Field:obj.Name
				throw new ArgumentException("obj");
			}
		}
		private BdIntSize GetSize(IBdFieldVisitor obj)
		{
			BdUIntFieldAttribute tAttrib = this.GetAttribute(obj);
			return tAttrib.Size;
		}

		public long GetRawLength(IBdFieldVisitor obj)
		{
			this.ValidateArg(obj);

			return (long) this.GetSize(obj);
		}


		public long SerializeTo(IBdFieldVisitor obj, IBdRawWriteContext context)
		{
			this.ValidateArg(obj);

			BdIntSize tSize = this.GetSize(obj);

			context.Serialize(this.GetValue(obj), this.GetAttribute(obj).Size);
			return (long)tSize;
		}

		public long DeserializeFrom(IBdFieldVisitor obj, IBdRawReadContext context)
		{
			this.ValidateArg(obj);

			BdIntSize tSize = this.GetSize(obj);
			this.SetValue(obj, context.Deserialize(this.GetAttribute(obj).Size));

			return (long)tSize;
		}
	}
}
