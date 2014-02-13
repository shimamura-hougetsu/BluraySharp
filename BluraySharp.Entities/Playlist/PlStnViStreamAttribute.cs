using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Architecture;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlStnViStreamAttribute : IBdPart
	{
		internal BdViCodingType CodingType { get; set; }

		internal BdViFormat VideoFormat
		{
			get
			{
				return (BdViFormat)this.FormatValue[0, 4];
			}
			set
			{
				this.FormatValue[0, 4] = (byte) value;
			}
		}
		internal BdViFrameRate FrameRate
		{
			get
			{
				return (BdViFrameRate)this.FormatValue[4, 4];
			}
			set
			{
				this.FormatValue[4, 4] = (byte)value;
			}
		}

		internal BdBitwise8 FormatValue { get; set; }

		internal byte[] ReservedForFutureUse { get; set; }

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
				this.CodingType = (BdViCodingType) context.DeserializeByte();
				this.FormatValue = context.Deserialize<BdBitwise8>();
				
				this.ReservedForFutureUse = context.DeserializeBytes(3);
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
