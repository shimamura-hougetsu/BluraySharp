using BluraySharp.Common.Serializing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdFieldSeeker<T> : IBdFieldSeeker
		where T : BdPart
	{
		private T thisObj;
		private int fieldIndex = 0;

		public BdFieldSeeker(T thisObj)
		{
			this.thisObj = thisObj;
		}

		public int Index
		{
			get
			{
				return this.fieldIndex;
			}
			set
			{
				if (value < 0 && value < BdFieldSeeker<T>.fields.Count)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this.fieldIndex = value;
			}
		}

		public BdFieldDescriptor Current
		{
			get
			{
				return BdFieldSeeker<T>.fields[this.fieldIndex];
			}
		}

		public int LowerBound
		{
			get
			{
				return 0;
			}
		}

		public int UpperBound
		{
			get
			{
				return BdFieldSeeker<T>.fields.Count;
			}
		}

		public string Name
		{
			get
			{
				return this.Current.Name;
			}
		}
		public Type Type
		{
			get
			{
				return this.Current.Type;
			}
		}

		public BdFieldAttribute Attribute
		{
			get
			{
				return this.Current.Attribute;
			}
		}
		public object Value
		{
			get
			{
				return this.Current.GetValue(this.thisObj);
			}
			set
			{
				this.Current.SetValue(this.thisObj, value);
			}
		}

		public BdFieldOffsetAttribute OffsetAttribute
		{
			get
			{
				return this.Current.OffsetAttribute;
			}
		}

		private static List<BdFieldDescriptor> fields = new List<BdFieldDescriptor>(BdFieldSeeker<T>.InitializeFields());

		private static IEnumerable<BdFieldDescriptor> InitializeFields()
		{
			MemberInfo[] tMembers = typeof(T).GetMembers();
			foreach (MemberInfo tMember in tMembers)
			{
				object[] tAttributes = tMember.GetCustomAttributes(typeof(BdFieldAttribute), true);
				if (tAttributes.Length == 1)
				{
					BdFieldAttribute tAttribute = tAttributes[0] as BdFieldAttribute;

					Debug.Assert(tMember.MemberType == MemberTypes.Property || tMember.MemberType == MemberTypes.Field);

					yield return new BdFieldDescriptor(tMember, tAttribute);
				}
			}
		}

		public ulong Offset
		{
			get
			{
				if (! this.IsOffsetSpecified)
				{
					//TODO: the field has no offset specified
					throw new ApplicationException();
				}
				
				string tOfsIndicator = this.OffsetAttribute.OffsetIndicator;
				if (!string.IsNullOrEmpty(tOfsIndicator))
				{
					MemberInfo[] tOfsMembers = typeof(T).GetMember(tOfsIndicator, MemberTypes.Property | MemberTypes.Field, BindingFlags.Instance | BindingFlags.Public);
					if (tOfsMembers.Length == 1)
					{
						BdFieldDescriptor tOfsField = new BdFieldDescriptor(tOfsMembers[0], null);

						return Convert.ToUInt64(tOfsField.GetValue(this.thisObj));
					}
					else
					{
						//TODO: cannot find offset indicator member for the field
						throw new ApplicationException();
					}
				}
				else
				{
					return this.OffsetAttribute.Offset;
				}
			}
			set
			{
				if (!this.IsOffsetSpecified)
				{
					//TODO: the field accepts no offset
					throw new ApplicationException();
				}

				string tOfsIndicator = this.OffsetAttribute.OffsetIndicator;
				if (!string.IsNullOrEmpty(tOfsIndicator))
				{
					MemberInfo[] tOfsMembers = typeof(T).GetMember(tOfsIndicator, MemberTypes.Property | MemberTypes.Field, BindingFlags.Instance | BindingFlags.Public);
					if (tOfsMembers.Length == 1)
					{
						BdFieldDescriptor tOfsField = new BdFieldDescriptor(tOfsMembers[0], null);

						tOfsField.SetValue(this.thisObj, Convert.ChangeType(value, tOfsField.Type));
					}
					else
					{
						//TODO: cannot find offset indicator member for the field
						throw new ApplicationException();
					}
				}
			}
		}

		public bool IsOffsetSpecified
		{
			get
			{
				return !object.ReferenceEquals(this.OffsetAttribute, null);
			}
		}
	}
}
