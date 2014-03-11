using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;

namespace BluraySharp.PlayList
{
	public class PlStnAuEntry : BdPart, IPlStnAuEntry
	{
		private PlStnEntry entryRoot =
			new PlStnEntry(PlStnStreamEntryType.PlayItem, (byte)BdAuCodingType.AuLPCM);

		[BdSubPartField]
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
		public BdAuCodingType CodecInfoType
		{
			get { return (BdAuCodingType)this.entryRoot.CodecType; }
			set { this.entryRoot.CodecType = (byte)value; }
		}
		public IPlStnCodecInfo CodecInfo
		{
			get { return this.entryRoot.CodecInfo; }
		}


		public override string ToString()
		{
			return "Primary Audio STN Entry";
		}
	}
}
