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
	public class PlStnViAttrInfo : BdPart, IPlStnViAttrInfo
	{
		#region FormatValue

		private BdBitwise8 formatOptions = new BdBitwise8();

		[BdSubPartField]
		private BdBitwise8 FormatOptions
		{
			get { return this.formatOptions; }
		}
		public BdViFormat VideoFormat
		{
			get
			{
				return (BdViFormat)this.FormatOptions[0, 4];
			}
			set
			{
				this.FormatOptions[0, 4] = (byte)value;
			}
		}		
		public BdViFrameRate FrameRate
		{
			get
			{
				return (BdViFrameRate)this.FormatOptions[4, 4];
			}
			set
			{
				this.FormatOptions[4, 4] = (byte)value;
			}
		}
		#endregion

		#region ReservedForFutureUse

		private byte[] reservedForFutureUse = new byte[3];

		[BdByteArrayField]
		private byte[] ReservedForFutureUse
		{
			get { return this.reservedForFutureUse; }
		}

		#endregion

		public override string ToString()
		{
			return "STN Video AttrInfo";
		}
	}
}
