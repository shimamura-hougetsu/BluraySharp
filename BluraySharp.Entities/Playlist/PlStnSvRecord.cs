using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlStnSvRecord : PlStnRecord, IPlStnSvRecord
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

		public IList<byte> SecondaryAudioRef { get; internal set; }

		public IList<byte> PipSubtitleRef { get; internal set; }

		internal PlStnViStreamAttribute Attribute { get; set; }

		internal byte ReservedForWordAlign1 { get; set; }
		internal byte ReservedForWordAlign2 { get; set; }

		public PlStnSvRecord()
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

			byte tFieldLen;

			//-tFieldLen = context.DeserializeByte();
			//-this.ReservedForWordAlign1 = context.DeserializeByte();
			//-this.SecondaryAudioRef = context.Deserialize(tFieldLen).ToList();

			//-tFieldLen = context.DeserializeByte();
			//-this.ReservedForWordAlign2 = context.DeserializeByte();
			//-this.PipSubtitleRef = context.Deserialize(tFieldLen).ToList();

			return context.Position;
		}

		public override long RawLength
		{
			get
			{
				return base.RawLength
					+ this.Attribute.GetRawLength()
					+ sizeof(byte) * 2 + sizeof(byte) * this.SecondaryAudioRef.Count
					+ sizeof(byte) * 2 + sizeof(byte) * this.PipSubtitleRef.Count;
			}
		}
	}
}
