using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;

namespace BluraySharp.PlayList
{
	public class PlStnIgEntry : BdPart, IPlStnIgEntry
	{
		#region Entry Root

		private PlStnEntryRoot entryRoot =
			new PlStnEntryRoot(PlStnStreamEntryType.PlayItem, (byte)BdIgCodingType.GxInterractive);

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
		public BdIgCodingType CodecInfoType
		{
			get { return (BdIgCodingType)this.entryRoot.CodecInfoType; }
			set { this.entryRoot.CodecInfoType = (byte)value; }
		}
		public IPlStnCodecInfo CodecInfo
		{
			get { return this.entryRoot.CodecInfo; }
		}

		#endregion

		public override string ToString()
		{
			return "Interractive Graphics STN Entry";
		}
	}
}
