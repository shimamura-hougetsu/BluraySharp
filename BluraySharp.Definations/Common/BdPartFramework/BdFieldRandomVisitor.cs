using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdFieldRandomVisitor : IBdFieldVisitor
	{
		private object root;
		private IBdFieldDescriptor field;

		public BdFieldRandomVisitor(object root, IBdFieldDescriptor field)
		{
			// TODO: Complete member initialization
			this.root = root;
			this.field = field;
		}

		public IBdFieldVisitor OffsetIndicator
		{
			get { return null; }
		}

		public IBdFieldVisitor LengthIndicator
		{
			get { return null; }
		}

		public object Value
		{
			get
			{
				return this.field.GetValue(this.root);
			}
			set
			{
				this.field.SetValue(this.root, value);
			}
		}

		public BdFieldAttribute Attribute
		{
			get { return this.field.Attribute; }
		}

		public string Name
		{
			get { return this.field.Name; }
		}

		public Type Type
		{
			get { return this.field.Type; }
		}
	}
}
