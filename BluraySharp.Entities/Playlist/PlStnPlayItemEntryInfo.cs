using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class PlStnPlayItemEntryInfo : BdPart, IPlStnPlayItemEntryInfo
	{
		[BdUIntField(BdIntSize.U16)]
		public ushort StreamProgId
		{
			get;
			set;
		}

		private byte[] reservedForFutureUse = new byte[6];
		[BdByteArrayField]
		private byte[] ReservedForFutureUse
		{
			get { return this.reservedForFutureUse; }
		}

		public override string ToString()
		{
			return "STN Entry Refering a PlayItem";
		}
	}
}
