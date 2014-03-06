using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdFieldTraverser<T> : IBdFieldTraverser
		where T : BdPart
	{
		private T thisObj;
		private int fieldIndex = 0;

		public BdFieldTraverser(T thisObj)
		{
			this.thisObj = thisObj;
		}

		#region Seeker


		private IBdFieldDescriptor Current
		{
			get
			{
				return BdFieldTraverser<T>.fields[this.fieldIndex];
			}
		}

		public int Index
		{
			get
			{
				return this.fieldIndex;
			}
			set
			{
				if (value < 0 && value < BdFieldTraverser<T>.fields.Count)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this.fieldIndex = value;
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
				return BdFieldTraverser<T>.fields.Count;
			}
		}

		#endregion 

		string IBdFieldInfo.Name
		{
			get
			{
				return this.Current.Name;
			}
		}

		Type IBdFieldInfo.Type
		{
			get
			{
				return this.Current.Type;
			}
		}

		BdFieldAttribute IBdFieldInfo.Attribute
		{
			get
			{
				return this.Current.Attribute;
			}
		}

		object IBdFieldVisitor.Value
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

		private IBdFieldDescriptor GetFieldDescriptor(string memberName)
		{
			if (string.IsNullOrEmpty(memberName))
			{
				//TODO: member name not specified.
				return null;
			}

			MemberInfo[] tOfsMembers = typeof(T).GetMember(memberName, MemberTypes.Property | MemberTypes.Field, BindingFlags.Instance | BindingFlags.Public);
			if (tOfsMembers.Length != 1)
			{
				//TODO: cannot find offset indicator member for the field
				return null;
			}

			return new BdFieldDescriptor(tOfsMembers[0], null);
		}

		IBdFieldVisitor IBdFieldVisitor.OffsetIndicator
		{
			get
			{
				BdFieldAttribute tAttrib = this.Current.Attribute;
				if (tAttrib.RefEquals(null) || tAttrib.OffsetIndicator.RefEquals(null))
				{
					return null;
				}

				IBdFieldDescriptor tOffsetField = this.GetFieldDescriptor(tAttrib.OffsetIndicator);
				if (tOffsetField.RefEquals(null))
				{
					//TODO: FieldNotFound
					throw new ApplicationException();
				}
				return new BdFieldRandomVisitor(this.thisObj, tOffsetField);
			}
		}

		IBdFieldVisitor IBdFieldVisitor.LengthIndicator
		{
			get
			{
				BdFieldAttribute tAttrib = this.Current.Attribute;
				if (tAttrib.RefEquals(null) || tAttrib.LengthIndicator.RefEquals(null))
				{
					return null;
				}

				IBdFieldDescriptor tLengthField = this.GetFieldDescriptor(tAttrib.LengthIndicator);
				if (tLengthField.RefEquals(null))
				{
					//FieldNotFound
					throw new ApplicationException();
				}
				return new BdFieldRandomVisitor(this.thisObj, tLengthField);
			}
		}


		IBdFieldVisitor IBdFieldVisitor.SkipIndicator
		{
			get
			{
				BdFieldAttribute tAttrib = this.Current.Attribute;
				if (tAttrib.RefEquals(null) || tAttrib.SkipIndicator.RefEquals(null))
				{
					return null;
				}

				IBdFieldDescriptor tSkipField = this.GetFieldDescriptor(tAttrib.SkipIndicator);
				if (tSkipField.RefEquals(null))
				{
					//FieldNotFound
					throw new ApplicationException();
				}
				return new BdFieldRandomVisitor(this.thisObj, tSkipField);
			}
		}
		
		private static List<BdFieldDescriptor> fields = new List<BdFieldDescriptor>(BdFieldTraverser<T>.InitializeFields());

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
		/*
		public ulong Offset
		{
			get
			{
				if (! this.IsOffsetSpecified)
				{
					//TODO: the field has no offset specified
					throw new NotSupportedException();
				}
				
				string tOfsIndicator = this.OffsetAttribute.OffsetIndicator;
				if (!string.IsNullOrEmpty(tOfsIndicator))
				{
					return this.GetUIntMember(tOfsIndicator);
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
					throw new NotSupportedException();
				}

				string tOfsIndicator = this.OffsetAttribute.OffsetIndicator;
				if (!string.IsNullOrEmpty(tOfsIndicator))
				{
					this.SetUIntMember(tOfsIndicator, value);
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
		*/
	}
}
