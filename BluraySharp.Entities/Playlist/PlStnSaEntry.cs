using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public class PlStnSaEntry : BdPart, IPlStnSaEntry
	{
		#region Entry Root
		private PlStnEntryRoot entryRoot =
			new PlStnEntryRoot(PlStnStreamEntryType.PlayItem, (byte)BdSaCodingType.SaDtsHD);

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
		public BdSaCodingType CodecInfoType
		{
			get { return (BdSaCodingType)this.entryRoot.CodecInfoType; }
			set { this.entryRoot.CodecInfoType = (byte)value; }
		}
		public IPlStnCodecInfo CodecInfo
		{
			get { return this.entryRoot.CodecInfo; }
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
