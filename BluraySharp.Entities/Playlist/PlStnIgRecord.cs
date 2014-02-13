using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlStnIgRecord : PlStnRecord, IPlStnIgRecord
	{
		public BdIgCodingType CodingType
		{
			get
			{
				return this.Attribute.CodingType;
			}
			set
			{
				this.Attribute.CodingType = value;
			}
		}

		public BdLang Language
		{
			get
			{
				return this.Attribute.Language;
			}
			set
			{
				this.Attribute.Language = value;
			}
		}

		internal PlStnIgStreamAttribute Attribute { get; set; }

		public PlStnIgRecord()
		{
			this.Attribute = new PlStnIgStreamAttribute();
		}

		public override long SerializeTo(Architecture.IBdRawWriteContext context)
		{
			return base.SerializeTo(context);
		}

		public override long DeserializeFrom(Architecture.IBdRawReadContext context)
		{
			base.DeserializeFrom(context);
			this.Attribute = context.Deserialize<PlStnIgStreamAttribute>();

			return context.Position;
		}

		public override long RawLength
		{
			get
			{
				return base.RawLength + this.Attribute.GetRawLength();
			}
		}
	}
}
