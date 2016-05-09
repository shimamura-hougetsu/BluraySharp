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
			this.scopeIndicator = 
				BdFieldTraverser<T>.GetIndicatorFieldVisitor(this.thisObj);
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
			get { return this.fieldIndex; }
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
			get { return 0; }
		}

		public int UpperBound
		{
			get { return BdFieldTraverser<T>.fields.Count; }
		}

		public IBdFieldVisitor ScopeIndicator
		{
			get { return this.scopeIndicator; }
		}

		private IBdFieldVisitor scopeIndicator;

		#endregion

		#region IBdFieldVisitor.*

		string IBdFieldInfo.Name
		{
			get { return this.Current.Name; }
		}

		Type IBdFieldInfo.Type
		{
			get { return this.Current.Type; }
		}

		BdFieldAttribute IBdFieldInfo.Attribute
		{
			get { return this.Current.Attribute; }
		}

		object IBdFieldVisitor.Value
		{
			get { return this.Current.GetValue(this.thisObj); }
			set { this.Current.SetValue(this.thisObj, value); }
		}

		IBdFieldVisitor IBdFieldVisitor.OffsetIndicator
		{
			get
			{
				BdFieldAttribute tAttrib = this.Current.Attribute;
				if (tAttrib.IsNull() || tAttrib.OffsetIndicator.IsNull())
				{
					return null;
				}

				IBdFieldDescriptor tOffsetField = 
					BdFieldTraverser<T>.GetFieldDescriptor(tAttrib.OffsetIndicator, null);
				if (tOffsetField.IsNull())
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
				if (tAttrib.IsNull() || tAttrib.LengthIndicator.IsNull())
				{
					return null;
				}

				IBdFieldDescriptor tLengthField =
					BdFieldTraverser<T>.GetFieldDescriptor(tAttrib.LengthIndicator, null);
				if (tLengthField.IsNull())
				{
					//TODO: FieldNotFound
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
				if (tAttrib.IsNull() || tAttrib.SkipIndicator.IsNull())
				{
					return null;
				}

				IBdFieldDescriptor tSkipField =
					BdFieldTraverser<T>.GetFieldDescriptor(tAttrib.SkipIndicator, null);
				if (tSkipField.IsNull())
				{
					//TODO: FieldNotFound
					throw new ApplicationException();
				}
				return new BdFieldRandomVisitor(this.thisObj, tSkipField);
			}
		}

		uint IBdFieldVisitor.OptionalLength
		{
			get
			{
				BdFieldAttribute tAttrib = this.Current.Attribute;
				if (tAttrib.IsNull())
				{
					return 0;
				}

				return tAttrib.OptionalLength;
			}
		}

		#endregion

		#region Fields of type, shared and static

		private static List<IBdFieldDescriptor> fields = 
			new List<IBdFieldDescriptor>(BdFieldTraverser<T>.InitializeFields());

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

		private static IBdFieldDescriptor GetFieldDescriptor(string memberName, BdFieldAttribute attribute)
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

			return new BdFieldDescriptor(tOfsMembers[0], attribute);
		}
		
		private static BdPartScopeAttribute indicatorFieldDescriptor = InitializeIndicatorFieldDescriptor();
		private static BdPartScopeAttribute InitializeIndicatorFieldDescriptor()
		{
			object[] tAttributes =
				typeof(T).GetCustomAttributes(typeof(BdPartScopeAttribute), true);
			if (tAttributes.Length != 1)
			{
				return null;
			}

			BdPartScopeAttribute tAttribute =
				tAttributes[0] as BdPartScopeAttribute;

			if (tAttribute.Size == BdIntSize.None ||
				tAttribute.Size == BdIntSize.Auto ||
				!Enum.IsDefined(typeof(BdIntSize), tAttribute.Size))
			{
				//TODO: Invalid integer type
				throw new ApplicationException();
			}

			return tAttribute;
		}

		private static IBdFieldVisitor GetIndicatorFieldVisitor(T thisObj)
		{
			if(indicatorFieldDescriptor == null)
			{
				return null;
			}
			else
			{
				BdFieldAttribute tScopeIndicAttrib =
					new BdUIntFieldAttribute(indicatorFieldDescriptor.Size);

				if (indicatorFieldDescriptor.IndicatorField.IsNull())
				{
					//the indicator is read and calculated to be written, while not stored in memory
					return new BdFieldVirtualVisitor<ulong>(
						typeof(T).Name + " Scope Indicator",
						tScopeIndicAttrib
						);
				}
				else
				{
					//stored in a field of this class
					IBdFieldDescriptor tIndField =
						BdFieldTraverser<T>.GetFieldDescriptor(
							indicatorFieldDescriptor.IndicatorField,
							tScopeIndicAttrib);
					return new BdFieldRandomVisitor(thisObj, tIndField);
				}
			}
		}

		#endregion
	}
}
