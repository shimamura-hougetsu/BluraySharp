using BluraySharp.Common.BdPartFramework;

namespace BluraySharp.PlayList
{
	internal class PlStnEntryRoot : BdPart
	{
		public PlStnEntryRoot(PlStnEntryType entryType, byte codecType)
		{
			this.EntryInfoRoot = new PlStnEntryInfoRoot(entryType);
			this.CodecInfoRoot = new PlStnCodecInfoRoot(codecType);
		}

		#region EntryInfo Root

		[BdSubPartField]
		private PlStnEntryInfoRoot EntryInfoRoot { get; set; }

		public PlStnEntryType EntryType
		{
			get { return this.EntryInfoRoot.EntryType; }
			set { this.EntryInfoRoot.EntryType = value; }
		}
		public IPlStnEntryInfo EntryInfo
		{
			get { return this.EntryInfoRoot.EntryInfo; }
		}

		#endregion
		
		#region CodecInfo Root

		[BdSubPartField]
		private PlStnCodecInfoRoot CodecInfoRoot { get; set; }

		public byte CodecInfoType
		{
			get { return this.CodecInfoRoot.CodecInfoType; }
			set { this.CodecInfoRoot.CodecInfoType = value; }
		}
		public IPlStnCodecInfo CodecInfo
		{
			get { return this.CodecInfoRoot.CodecInfo; }
		}

		#endregion

		public override string ToString()
		{
			return "Internal StnEntry Serializing Helper";
		}
	}
}
