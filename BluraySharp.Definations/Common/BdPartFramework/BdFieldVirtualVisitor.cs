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
		public uint OptionalLength
		{
			get { return 0; }
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
