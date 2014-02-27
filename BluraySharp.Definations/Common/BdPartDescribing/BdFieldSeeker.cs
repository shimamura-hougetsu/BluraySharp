using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BluraySharp.Common.BdPartDescribing
{
	internal class BdFieldSeeker<T>
	{
		private T thisObj;
		private int fieldIndex = 0;

		public BdFieldSeeker(T thisObj)
		{
			this.thisObj = thisObj;
		}

		public int Count
		{
			get
			{
				return BdFieldSeeker<T>.fields.Count;
			}
		}

		public BdFieldDescriptor FieldDescriptor
		{
			get
			{
				return BdFieldSeeker<T>.fields[this.fieldIndex];
			}
		}

		public void UpdateOffset(long offset)
		{
			if (this.FieldDescriptor.FieldOffset != null)
			{
				string tOfsIndicator = this.FieldDescriptor.FieldOffset.OffsetIndicator;
				if (tOfsIndicator != null)
				{
					MemberInfo[] tOfsMembers = typeof(T).GetMember(tOfsIndicator, MemberTypes.Property | MemberTypes.Field, BindingFlags.Default);
					if (tOfsMembers.Length == 1)
					{
						BdFieldDescriptor tOfsField = new BdFieldDescriptor(tOfsMembers[0], null);

						tOfsField.SetValue(this.thisObj, Convert.ChangeType(offset, tOfsField.Type));
					}
				}
			}
		}

		public bool Seek(int index)
		{
			if (index >= 0 && index < BdFieldSeeker<T>.fields.Count)
			{
				this.fieldIndex = index;
				return true;
			}

			return false;
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
	}
}
