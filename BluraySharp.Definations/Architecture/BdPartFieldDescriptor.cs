using System.Reflection;
using System;

namespace BluraySharp.Architecture
{
	public class BdPartFieldDescriptor
	{
		public string Name
		{
			get
			{
				return this.Info.Name;
			}
		}

		public FieldInfo Info { get; private set; }
		public BdPartFieldAttribute Attribute { get; private set; }

		public BdPartFieldDescriptor(FieldInfo info, BdPartFieldAttribute attribute)
		{
			this.Info = info;
			this.Attribute = attribute;
		}

		private void SetValue(object theThis, object value)
		{
			this.Info.SetValue(theThis, value);
		}

		private object GetValue(object theThis)
		{
			return this.Info.GetValue(theThis);
		}

		private long GetByteCount(object theThis)
		{
			throw new NotImplementedException();
		}

		private int GetElementCount(object theThis)
		{
			throw new NotImplementedException();
		}
	}
}
