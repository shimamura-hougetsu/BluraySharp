using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;

namespace BluraySharp.PlayList
{
	public class PlStnAuEntry : BdPart, IPlStnAuEntry
	{
		#region Entry Root

		private PlStnEntryRoot entryRoot =
			new PlStnEntryRoot(PlStnEntryType.PlayItem, (byte)BdAuCodingType.AuLPCM);

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
		public BdAuCodingType AttrInfoType
		{
			get { return (BdAuCodingType)this.entryRoot.AttrInfoType; }
			set { this.entryRoot.AttrInfoType = (byte)value; }
		}
		public IPlStnAttrInfo AttrInfo
		{
			get { return this.entryRoot.AttrInfo; }
		}

		#endregion

		public override string ToString()
		{
			return "Primary Audio STN Entry";
		}
	}
}
