using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlStnAuRecord : PlStnRecord, IPlStnAuRecord
	{
		public BdAuCodingType CodingType
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

		public BdAuPresentationType Presentation
		{
			get
			{
				return this.Attribute.Presentation;
			}
			set
			{
				this.Attribute.Presentation = value;
			}
		}

		public BdAuSampleRate SampleFrequency
		{
			get
			{
				return this.Attribute.SampleFrequency;
			}
			set
			{
				this.Attribute.SampleFrequency = value;
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

		internal PlStnAuStreamAttribute Attribute { get; set; }

		public PlStnAuRecord()
		{
			this.Attribute = new PlStnAuStreamAttribute();
		}

		public override long SerializeTo(Architecture.IBdRawWriteContext context)
		{
			return base.SerializeTo(context);
		}

		public override long DeserializeFrom(Architecture.IBdRawReadContext context)
		{
			base.DeserializeFrom(context);
			this.Attribute = context.Deserialize<PlStnAuStreamAttribute>();

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
