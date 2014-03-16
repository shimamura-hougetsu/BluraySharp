using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class PlPlayMark : BdPart, IPlPlayMark
	{
		[BdUIntField(BdIntSize.U8)]
		private byte ReservedForFutureUse { get; set; }

		[BdUIntField(BdIntSize.U8)]
		public PlPlayMarkType MarkType { get; set; }

		[BdUIntField(BdIntSize.U16)]
		public ushort PlayItemSId { get; set; }


		private BdTime timeStamp = new BdTime();
		[BdSubPartField]
		public BdTime TimeStamp
		{
			get { return this.timeStamp; }
			set { this.timeStamp.Value = value.Value; }
		}

		[BdUIntField(BdIntSize.U16)]
		public ushort StreamProgId { get; set; }

		[BdUIntField(BdIntSize.U32)]
		public uint Duration { get; set; }

		public override string ToString()
		{
			return "PlayMark";
		}
	}
}
