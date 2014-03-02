using System;

namespace BluraySharp.Common.BdPartFramework
{
	internal abstract class BdFieldAttribute : Attribute
	{
		public BdFieldType FieldType { get; private set; }

		public BdFieldAttribute(BdFieldType type)
		{
			this.FieldType = type;
		}
	}
}
