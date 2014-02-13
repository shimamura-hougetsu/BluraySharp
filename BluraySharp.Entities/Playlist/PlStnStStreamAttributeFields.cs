using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Architecture;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public abstract class PlStnStStreamAttributeFields : IPlStnStStreamAttribute
	{
		internal BdStCodingType CodingType { get; private set; }

		public PlStnStStreamAttributeFields(BdStCodingType type)
		{
			this.CodingType = type;
		}

		public abstract long SerializeTo(IBdRawWriteContext context);

		public abstract long DeserializeFrom(IBdRawReadContext context);

		public abstract long RawLength { get; }
	}
}
