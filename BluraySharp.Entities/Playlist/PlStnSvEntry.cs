using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public class PlStnSvEntry : BdPart, IPlStnSvEntry
	{
		private PlStnEntry entryRoot =
			new PlStnEntry(PlStnStreamEntryType.PlayItem, (byte)BdViCodingType.ViAvc);
		private BdList<byte, byte> secondaryAudioIdRef
			= new BdList<byte,byte>();
		private BdList<byte, byte> pipSubtitleIdRef =
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
		public BdViCodingType CodecInfoType
		{
			get { return (BdViCodingType)this.entryRoot.CodecType; }
			set { this.entryRoot.CodecType = (byte)value; }
		}
		public IPlStnCodecInfo CodecInfo
		{
			get { return this.entryRoot.CodecInfo; }
		}


		[BdUIntField(BdIntSize.U8)]
		private byte SecondaryAudioIdRefCount
		{
			get { return (byte)this.secondaryAudioIdRef.Count; }
			set { this.secondaryAudioIdRef.SetCount(value); }
		}

		[BdUIntField(BdIntSize.U8)]
		public IBdList<byte> SecondaryAudioIdRef
		{
			get { return this.secondaryAudioIdRef; }
		}


		[BdUIntField(BdIntSize.U8)]
		private byte PipSubtitleIdRefCount
		{
			get { return (byte)this.pipSubtitleIdRef.Count; }
			set { this.pipSubtitleIdRef.SetCount(value); }
		}

		[BdUIntField(BdIntSize.U8)]
		public IBdList<byte> PipSubtitleIdRef
		{
			get { return this.pipSubtitleIdRef; }
		}

		public override string ToString()
		{
			return "Secondary Video STN Entry";
		}
	}
}
