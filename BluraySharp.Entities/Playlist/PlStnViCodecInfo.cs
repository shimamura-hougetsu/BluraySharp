using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Architecture;
using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public class PlStnViCodecInfo : BdPart, IPlStnViCodecInfo
	{
		private BdBitwise8 formatValue = new BdBitwise8();
		private byte[] reservedForFutureUse = new byte[3];

		[BdSubPartField]
		private BdBitwise8 FormatValue
		{
			get { return this.formatValue; }
		}
		public BdViFormat VideoFormat
		{
			get
			{
				return (BdViFormat)this.FormatValue[0, 4];
			}
			set
			{
				this.FormatValue[0, 4] = (byte)value;
			}
		}		
		public BdViFrameRate FrameRate
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

		[BdByteArrayField]
		private byte[] ReservedForFutureUse
		{
			get { return this.reservedForFutureUse; }
		}

		public override string ToString()
		{
			return "STN Video CodecInfo";
		}
	}
}
