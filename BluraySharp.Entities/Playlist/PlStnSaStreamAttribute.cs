using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Architecture;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlStnSaStreamAttribute : IBdPart
	{
		internal BdSaCodingType CodingType { get; set; }

		internal BdAuPresentationType Presentation
		{
			get
			{
				return (BdAuPresentationType)this.FormatValue[4, 4];
			}
			set
			{
				this.FormatValue[4, 4] = (byte)value;
			}
		}

		internal BdAuSampleRate SampleFrequency
		{
			get
			{
				return (BdAuSampleRate)this.FormatValue[4, 4];
			}
			set
			{
				this.FormatValue[4, 4] = (byte)value;
			}
		}

		internal BdBitwise8 FormatValue { get; set; }
		internal BdLang Language { get; set; }

		public long SerializeTo(IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			byte tFieldLen = context.DeserializeByte();
			context.EnterScope(tFieldLen);
			try
			{
				this.CodingType = (BdSaCodingType)context.DeserializeByte();
				this.FormatValue = context.Deserialize<BdBitwise8>();

				string tLangCode = context.DeserializeString(3, Encoding.UTF8);
				this.Language = BdLangCode.ValueOf(tLangCode);
			}
			finally
			{
				context.ExitScope();
			}

			return context.Position;
		}

		public long RawLength
		{
			get
			{
				return sizeof(byte) * 2 + this.FormatValue.GetRawLength() + sizeof(byte) * 3;
			}
		}
	}
}
