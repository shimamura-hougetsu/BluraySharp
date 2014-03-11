using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;

namespace BluraySharp.PlayList
{
	public class PlStnAuEntry : BdPart, IPlStnAuEntry
	{
		#region Entry Root

		private PlStnEntryRoot entryRoot =
			new PlStnEntryRoot(PlStnStreamEntryType.PlayItem, (byte)BdAuCodingType.AuLPCM);

		[BdSubPartField]
		private PlStnEntryRoot EntryRoot
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

		#endregion

		public override string ToString()
		{
			return "Primary Audio STN Entry";
		}
	}
}
