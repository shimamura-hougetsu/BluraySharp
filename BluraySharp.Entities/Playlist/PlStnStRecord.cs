using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlStnStRecord : PlStnRecord, IPlStnStRecord
	{
		public BdStCodingType CodingType
		{
			get
			{
				return this.attribute.CodingType;
			}
			set
			{
				this.attribute.CodingType = value;
			}
		}

		public IPlStnStStreamAttribute Attribute
		{
			get
			{
				return this.attribute.Fields;
			}
		}

		private PlStnStStreamAttribute attribute = new PlStnStStreamAttribute();
		
		public override long SerializeTo(Architecture.IBdRawWriteContext context)
		{
			return base.SerializeTo(context);
		}

		public override long DeserializeFrom(Architecture.IBdRawReadContext context)
		{
			base.DeserializeFrom(context);

			this.attribute = context.Deserialize<PlStnStStreamAttribute>();

			return context.Position;
		}

		public override long RawLength
		{
			get
			{
				return base.RawLength + this.attribute.GetRawLength();
			}
		}
	}
}
