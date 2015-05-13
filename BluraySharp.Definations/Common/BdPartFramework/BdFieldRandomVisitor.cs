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

		public IBdFieldVisitor SkipIndicator
		{
			get { return null; }
		}

		public uint OptionalLength
		{
			get { return 0; }
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
