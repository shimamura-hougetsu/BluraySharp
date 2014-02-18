using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace BluraySharp.Architecture
{
	public class BdPartFieldDescriptorSet : IList<BdPartFieldDescriptor>
	{
		private List<BdPartFieldDescriptor> fields = new List<BdPartFieldDescriptor>();

		public BdPartFieldDescriptor this[string index]
		{
			get
			{
				BdPartFieldDescriptor tField = this.fields.First(xField => xField.Name == index);
				return tField;
			}
		}

		public BdPartFieldDescriptorSet(Type type)
		{
			foreach (FieldInfo iField in type.GetFields())
			{
				BdPartFieldAttribute[] tFieldAttribs = iField.GetCustomAttributes(typeof(BdPartFieldAttribute), true) as BdPartFieldAttribute[];

				if (tFieldAttribs != null && tFieldAttribs.Length > 0)
				{
					BdPartFieldAttribute tFieldAttrib = tFieldAttribs[0];

					this.fields.Add(new BdPartFieldDescriptor(iField, tFieldAttrib));
				}
			}
		}

		public BdPartFieldDescriptor this[int index]
		{
			get
			{
				return this.fields[index];
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public int IndexOf(BdPartFieldDescriptor item)
		{
			return fields.IndexOf(item);
		}

		void IList<BdPartFieldDescriptor>.Insert(int index, BdPartFieldDescriptor item)
		{
			throw new NotImplementedException();
		}

		public bool Contains(BdPartFieldDescriptor item)
		{
			return this.fields.Contains(item);
		}

		public void CopyTo(BdPartFieldDescriptor[] array, int arrayIndex)
		{
			this.fields.CopyTo(array, arrayIndex);
		}

		public int Count
		{
			get {
				return this.fields.Count;
			}
		}

		public bool IsReadOnly
		{
			get {
				return true;
			}
		}

		void IList<BdPartFieldDescriptor>.RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		public IEnumerator<BdPartFieldDescriptor> GetEnumerator()
		{
			return this.fields.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		void ICollection<BdPartFieldDescriptor>.Add(BdPartFieldDescriptor item)
		{
			throw new NotImplementedException();
		}

		void ICollection<BdPartFieldDescriptor>.Clear()
		{
			throw new NotImplementedException();
		}

		bool ICollection<BdPartFieldDescriptor>.Remove(BdPartFieldDescriptor item)
		{
			throw new NotImplementedException();
		}
	}
}
