using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlStnViRecord : PlStnRecord, IPlStnViRecord
	{
		public BdViCodingType CodingType
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

		public BdViFormat VideoFormat
		{
			get
			{
				return this.Attribute.VideoFormat;
			}
			set
			{
				this.Attribute.VideoFormat = value;
			}
		}

		public BdViFrameRate FrameRate
		{
			get
			{
				return this.Attribute.FrameRate;
			}
			set
			{
				this.Attribute.FrameRate = value;
			}
		}

		internal PlStnViStreamAttribute Attribute { get; set; }

		public PlStnViRecord()
		{
			this.Attribute = new PlStnViStreamAttribute();
		}

		public override long SerializeTo(Architecture.IBdRawWriteContext context)
		{
			return base.SerializeTo(context);
		}

		public override long DeserializeFrom(Architecture.IBdRawReadContext context)
		{
			base.DeserializeFrom(context);
			this.Attribute = context.Deserialize<PlStnViStreamAttribute>();

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
