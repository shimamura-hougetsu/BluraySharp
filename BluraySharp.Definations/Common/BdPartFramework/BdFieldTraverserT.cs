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

		public IBdFieldVisitor SeekerScopeIndicator{
			get
			{
				IBdFieldDescriptor tOffsetField = BdFieldTraverser<T>.seekerScopeIndicator;
				if (tOffsetField.RefEquals(null))
				{
					return null;
				}
				return new BdFieldRandomVisitor(this.thisObj, tOffsetField);
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

		IBdFieldVisitor IBdFieldVisitor.OffsetIndicator
		{
			get
			{
				BdFieldAttribute tAttrib = this.Current.Attribute;
				if (tAttrib.RefEquals(null) || tAttrib.OffsetIndicator.RefEquals(null))
				{
					return null;
				}

				IBdFieldDescriptor tOffsetField = BdFieldTraverser<T>.GetFieldDescriptor(tAttrib.OffsetIndicator);
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

				IBdFieldDescriptor tLengthField = BdFieldTraverser<T>.GetFieldDescriptor(tAttrib.LengthIndicator);
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

				IBdFieldDescriptor tSkipField = BdFieldTraverser<T>.GetFieldDescriptor(tAttrib.SkipIndicator);
				if (tSkipField.RefEquals(null))
				{
					//FieldNotFound
					throw new ApplicationException();
				}
				return new BdFieldRandomVisitor(this.thisObj, tSkipField);
			}
		}
		
		private static List<IBdFieldDescriptor> fields = 
			new List<IBdFieldDescriptor>(BdFieldTraverser<T>.InitializeFields());
		private static IBdFieldDescriptor seekerScopeIndicator = 
			BdFieldTraverser<T>.InitializeSeekerScopeIndicator();

		private static IEnumerable<BdFieldDescriptor> InitializeFields()
		{
			MemberInfo[] tMembers = typeof(T).GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
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

		private static IBdFieldDescriptor InitializeSeekerScopeIndicator()
		{
			object[] tAttributes = 
				typeof(T).GetCustomAttributes(typeof(BdPartLengthIndicatorAttribute), true);
			if(tAttributes.Length != 1)
			{
				return null;
			}

			BdPartLengthIndicatorAttribute tAttribute =
				tAttributes[0] as BdPartLengthIndicatorAttribute;
			if(tAttribute.Indicator.RefEquals(null))
			{
				return null;
			}

			return BdFieldTraverser<T>.GetFieldDescriptor(tAttribute.Indicator);
		}

		private static IBdFieldDescriptor GetFieldDescriptor(string memberName)
		{
			if (string.IsNullOrEmpty(memberName))
			{
				//TODO: member name not specified.
				return null;
			}

			MemberInfo[] tOfsMembers = typeof(T).GetMember(
				memberName, MemberTypes.Property | MemberTypes.Field, 
				BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
				);

			if (tOfsMembers.Length != 1)
			{
				//TODO: cannot find scope indicator member for the field
				throw new ApplicationException();
			}

			return new BdFieldDescriptor(tOfsMembers[0], null);
		}
	}
}
