using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;

namespace BluraySharp.PlayList
{
	public class PlStnStEntry : BdPart, IPlStnStEntry
	{
		#region Entry Root
		private PlStnEntryRoot entryRoot =
			new PlStnEntryRoot(PlStnEntryType.PlayItem, (byte)BdStCodingType.GxPresentation);

		[BdSubPartField]
		private PlStnEntryRoot EntryRoot
		{
			get { return this.entryRoot; }
		}
		public PlStnEntryType EntryType
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
			get { return (BdStCodingType)this.entryRoot.CodecInfoType; }
			set { this.entryRoot.CodecInfoType = (byte)value; }
		}
		public IPlStnCodecInfo CodecInfo
		{
			get { return this.entryRoot.CodecInfo; }
		}
		#endregion

		public override string ToString()
		{
			return "Subtitle(Pg/Text) STN Entry";
		}
	}
}
