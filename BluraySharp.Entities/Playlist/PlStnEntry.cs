using BluraySharp.Common.BdPartFramework;

namespace BluraySharp.PlayList
{
	internal class PlStnEntry : BdPart
	{
		public PlStnEntry(PlStnStreamEntryType entryType, byte codecType)
		{
			this.entryInfo = new PlStnEntryInfoRoot(entryType);
			this.codecInfo = new PlStnCodecInfoRoot(codecType);
		}

		private PlStnEntryInfoRoot entryInfo;
		private PlStnCodecInfoRoot codecInfo;

		[BdSubPartField]
		private PlStnEntryInfoRoot EntryInfoRoot
		{
			get { return this.entryInfo; }
		}

		[BdSubPartField]
		private PlStnCodecInfoRoot CodecInfoRoot
		{
			get { return this.codecInfo; }
		}

		public PlStnStreamEntryType EntryType
		{
			get { return this.entryInfo.EntryType; }
			set { this.entryInfo.EntryType = value; }
		}

		public IPlStnEntryInfo EntryInfo
		{
			get { return this.entryInfo.EntryInfo; }
		}

		public byte CodecType
		{
			get { return this.codecInfo.CodecType; }
			set { this.codecInfo.CodecType = value; }
		}

		public IPlStnCodecInfo CodecInfo
		{
			get { return this.codecInfo.CodecInfo; }
		}

		public override string ToString()
		{
			return "Internal StnEntry Serializing Helper";
		}
	}
}
