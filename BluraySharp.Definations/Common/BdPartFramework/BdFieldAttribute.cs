using System;

namespace BluraySharp.Common.BdPartFramework
{
	internal abstract class BdFieldAttribute : Attribute
	{
		public BdFieldType FieldType { get; private set; }

		public string OffsetIndicator { get; set; }
		public string LengthIndicator { get; set; }

		public BdFieldAttribute(BdFieldType type)
		{
			this.FieldType = type;
		}
	}
}
