using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using System;

namespace BluraySharp.PlayList
{
	public class PlStnSubPlayItemEntryInfo : BdPart, IPlStnSubPlayItemEntryInfo
	{
		private byte[] reservedForFutureUse = new byte[4];

		[BdUIntField(BdIntSize.U8)]
		public byte SubPathId
		{
			get;
			set;
		}

		[BdUIntField(BdIntSize.U8)]
		public byte SubClipEntryId
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

		[BdByteArrayField]
		private byte[] ResersvedForFutureUse
		{
			get { return this.reservedForFutureUse; }
		}

		public override string ToString()
		{
			return "STN Entry refering a subplayitem";
		}
	}
}
