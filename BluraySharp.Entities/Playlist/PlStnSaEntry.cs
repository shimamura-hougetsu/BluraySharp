using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public class PlStnSaEntry : BdPart, IPlStnSaEntry
	{
		#region Entry Root
		private PlStnEntryRoot entryRoot =
			new PlStnEntryRoot(PlStnEntryType.PlayItem, (byte)BdSaCodingType.SaDtsHD);

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
		public BdSaCodingType AttrInfoType
		{
			get { return (BdSaCodingType)this.entryRoot.AttrInfoType; }
			set { this.entryRoot.AttrInfoType = (byte)value; }
		}
		public IPlStnAttrInfo AttrInfo
		{
			get { return this.entryRoot.AttrInfo; }
		}

		#endregion

		#region PrimaryAudioIdRef

		[BdUIntField(BdIntSize.U8)]
		private byte PrimaryAudioIdRefCount
		{
			get { return (byte)this.primaryAudioIdRef.Count; }
			set { this.primaryAudioIdRef.SetCount(value);}
		}

		private BdList<byte, byte> primaryAudioIdRef =
			new BdList<byte, byte>();

		[BdUIntField(BdIntSize.U8)]
		public IBdList<byte> PrimaryAudioIdRef
		{
			get { return this.primaryAudioIdRef; }
		}

		#endregion

		public override string ToString()
		{
			return "Secondary Audio STN Entry Attributes";
		}
	}
}
