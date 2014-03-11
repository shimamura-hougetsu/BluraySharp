using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public class PlStnSaEntry : BdPart, IPlStnSaEntry
	{
		private PlStnEntry entryRoot =
			new PlStnEntry(PlStnStreamEntryType.PlayItem, (byte)BdSaCodingType.SaDtsHD);
		private BdList<byte, byte> primaryAudioIdRef =
			new BdList<byte, byte>();

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
		public BdSaCodingType CodecInfoType
		{
			get { return (BdSaCodingType)this.entryRoot.CodecType; }
			set { this.entryRoot.CodecType = (byte)value; }
		}
		public IPlStnCodecInfo CodecInfo
		{
			get { return this.entryRoot.CodecInfo; }
		}

		[BdUIntField(BdIntSize.U8)]
		private byte PrimaryAudioIdRefCount
		{
			get { return (byte)this.primaryAudioIdRef.Count; }
			set { this.primaryAudioIdRef.SetCount(value);}
		}

		[BdUIntField(BdIntSize.U8)]
		public IBdList<byte> PrimaryAudioIdRef
		{
			get { return this.primaryAudioIdRef; }
		}

		public override string ToString()
		{
			return "Secondary Audio STN Entry Attributes";
		}
	}
}
