using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public class PlStnSvEntry : BdPart, IPlStnSvEntry
	{
		#region Entry Root

		private PlStnEntryRoot entryRoot =
			new PlStnEntryRoot(PlStnEntryType.PlayItem, (byte)BdViCodingType.ViAvc);

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
		public BdViCodingType CodecInfoType
		{
			get { return (BdViCodingType)this.entryRoot.CodecInfoType; }
			set { this.entryRoot.CodecInfoType = (byte)value; }
		}
		public IPlStnCodecInfo CodecInfo
		{
			get { return this.entryRoot.CodecInfo; }
		}

		
		#endregion

		#region SecondaryAudioIdRef

		private BdList<byte, byte> secondaryAudioIdRef
			= new BdList<byte,byte>();

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

		#endregion

		#region PipSubtitleIdRef

		private BdList<byte, byte> pipSubtitleIdRef =
			new BdList<byte, byte>();

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

		#endregion

		public override string ToString()
		{
			return "Secondary Video STN Entry";
		}
	}
}
