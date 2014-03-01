using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BluraySharp.Common.BdPartRawIoHelper
{
	internal class BdFieldDescriptor : IBdFieldDescription
	{
		private MemberInfo MemberInfo { get; set; }

		public BdFieldAttribute Attribute { get; private set; }

		public BdFieldOffsetAttribute OffsetAttribute { get; private set; }

		public string Name
		{
			get
			{
				return this.MemberInfo.Name;
			}
		}

		public Type Type
		{
			get
			{
				switch (this.MemberInfo.MemberType)
				{
					case MemberTypes.Field:
						FieldInfo tField = this.MemberInfo as FieldInfo;
						return tField.FieldType;
					case MemberTypes.Property:
						PropertyInfo tProperty = this.MemberInfo as PropertyInfo;
						return tProperty.PropertyType;
					default:
						//TODO: Invalid bluray field type
						throw new ApplicationException();
				}
			}
		}

		public object GetValue(object thisObj)
		{
			switch (this.MemberInfo.MemberType)
			{
				case MemberTypes.Field:
					FieldInfo tField = this.MemberInfo as FieldInfo;
					return tField.GetValue(thisObj);
				case MemberTypes.Property:
					PropertyInfo tProperty = this.MemberInfo as PropertyInfo;
					return tProperty.GetValue(thisObj, null);
				default:
					//TODO: Invalid bluray field type
					throw new ApplicationException();
			}
		}

		public void SetValue(object thisObj, object value)
		{
			switch (this.MemberInfo.MemberType)
			{
				case MemberTypes.Field:
					FieldInfo tField = this.MemberInfo as FieldInfo;
					tField.SetValue(thisObj, value);
					break;
				case MemberTypes.Property:
					PropertyInfo tProperty = this.MemberInfo as PropertyInfo;
					tProperty.SetValue(thisObj, value, null);
					break;
				default:
					//TODO: Invalid bluray field type
					throw new ApplicationException();
			}
		}

		public BdFieldDescriptor(MemberInfo info, BdFieldAttribute attribute)
		{
			this.MemberInfo = info;
			this.Attribute = attribute;

			object[] tOfsAtrributes = info.GetCustomAttributes(typeof(BdFieldOffsetAttribute), true);
			if(tOfsAtrributes.Length == 1)
			{
				this.OffsetAttribute = tOfsAtrributes[0] as BdFieldOffsetAttribute;
			}
		}
	}
}
