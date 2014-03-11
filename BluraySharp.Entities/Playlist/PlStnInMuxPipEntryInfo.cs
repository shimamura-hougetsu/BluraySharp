using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class PlStnInMuxPipEntryInfo : BdPart, IPlStnInMuxPipEntryInfo
	{
		[BdUIntField(BdIntSize.U8)]
		public byte SubPathId
		{
			get;
			set;
		}

		[BdUIntField(BdIntSize.U16)]
		public ushort StreamProgId
		{
			get;
			set;
		}

		private byte[] reservedForFutureUse = new byte[5];
		[BdByteArrayField]
		public byte[] ReservedForFutureUse
		{
			get { return this.reservedForFutureUse; }
		}

		public override string ToString()
		{
			return "STN Entry refering a InMuxPip subpath";
		}
	}
}
