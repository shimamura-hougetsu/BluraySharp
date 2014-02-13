using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlStnSaRecord : PlStnRecord, IPlStnSaRecord
	{
		public BdSaCodingType CodingType
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

		internal PlStnSaStreamAttribute Attribute { get; set; }
		
		
		internal byte ReservedForWordAlign { get; set; }
		public IList<byte> PrimaryAudioRef { get; internal set; }

		public PlStnSaRecord()
		{
			this.Attribute = new PlStnSaStreamAttribute();
		}

		public override long SerializeTo(Architecture.IBdRawWriteContext context)
		{
			return base.SerializeTo(context);
		}

		public override long DeserializeFrom(Architecture.IBdRawReadContext context)
		{
			base.DeserializeFrom(context);
			this.Attribute = context.Deserialize<PlStnSaStreamAttribute>();

			byte tFieldLen = context.DeserializeByte(); 
			this.ReservedForWordAlign = context.DeserializeByte();
			this.PrimaryAudioRef = context.DeserializeBytes(tFieldLen).ToList();

			return context.Position;
		}

		public override long RawLength
		{
			get
			{
				return base.RawLength +
					this.Attribute.GetRawLength() +
					sizeof(byte)*2 + sizeof(byte) * this.PrimaryAudioRef.Count;
			}
		}
	}
}
