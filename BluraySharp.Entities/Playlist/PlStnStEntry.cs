﻿using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;

namespace BluraySharp.PlayList
{
	public class PlStnStEntry : BdPart, IPlStnStEntry
	{
		private PlStnEntry entryRoot =
			new PlStnEntry(PlStnStreamEntryType.PlayItem, (byte)BdStCodingType.Pg);

		private PlStnEntry EntryRoot
		{
			get { return this.entryRoot; }
		}

		public PlStnStreamEntryType EntryType
		{
			get { return this.entryRoot.EntryType; }
			set { this.entryRoot.EntryType = value; }
		}

		public IPlStnEntryInfo EntryInfo
		{
			get { return this.entryRoot.EntryInfo; }
		}

		public BdStCodingType CodecInfoType
		{
			get { return (BdStCodingType)this.entryRoot.CodecType; }
			set { this.entryRoot.CodecType = (byte)value; }
		}

		public IPlStnCodecInfo CodecInfo
		{
			get { return this.entryRoot.CodecInfo; }
		}

		public override string ToString()
		{
			return "Subtitle(Pg/Text) StnEntry";
		}
	}
}
