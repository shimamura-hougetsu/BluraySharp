using BluraySharp.Common.BdPartFramework;

namespace BluraySharp.PlayList
{
	internal class PlStnEntryRoot : BdPart
	{
		public PlStnEntryRoot(PlStnStreamEntryType entryType, byte codecType)
		{
			this.EntryInfoRoot = new PlStnEntryInfoRoot(entryType);
			this.CodecInfoRoot = new PlStnCodecInfoRoot(codecType);
		}

		#region EntryInfo Root

		[BdSubPartField]
		private PlStnEntryInfoRoot EntryInfoRoot { get; set; }

		public PlStnStreamEntryType EntryType
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

		public byte CodecType
		{
			get { return this.CodecInfoRoot.CodecType; }
			set { this.CodecInfoRoot.CodecType = value; }
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
