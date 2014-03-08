using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdFieldVirtualVisitor<T> : IBdFieldVisitor
	{
		private T value;

		public IBdFieldVisitor OffsetIndicator
		{
			get { return null; }
		}

		public IBdFieldVisitor LengthIndicator
		{
			get { return null; }
		}

		public IBdFieldVisitor SkipIndicator
		{
			get { return null; }
		}

		public object Value
		{
			get
			{
				return this.value;
			}
			set
			{
				this.value = (T) value;	
			}
		}

		public BdFieldAttribute Attribute
		{
			get;
			private set;
		}

		public string Name
		{
			get;
			private set;
		}

		public Type Type
		{
			get { return typeof(T); }
		}

		public BdFieldVirtualVisitor(string name, BdFieldAttribute attribute)
		{
			this.Name = name;
			this.Attribute = attribute;
		}
	}
}
