using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharpTest
{
	public class TestClass : BdPart
	{
		private string mplsMark = "MPLS";
		private string mplsVer = "0200";
		private uint playListOfs = 0;
		private uint playMarkOfs = 0;
		private uint extDataOfs = 0;
		private byte[] reservedForFutureUse = new byte[20];
		private uint appInfoLen = 0;
		private BdExtensionData appInfoSeg = new BdExtensionData();
		private uint playListLen = 0;
		private BdExtensionData playListSeg = new BdExtensionData();
		private uint playMarkLen = 0;
		private BdExtensionData playMarkSeg = new BdExtensionData();
		private uint extDataLen = 0;
		private BdExtensionData extDataSeg = null;

		public bool playListSkip = false;
		public bool playMarkSkip = false;
		public bool extDataSkip = true;

		[BdStringField(4, BdCharacterCodingType.UTF8)]
		public string MplsMark
		{
			get { return this.mplsMark; }
			set { this.mplsMark = value; }
		}

		[BdStringField(4, BdCharacterCodingType.UTF8)]
		public string MplsVer
		{
			get { return this.mplsVer; }
			set { this.mplsVer = value; }
		}

		[BdUIntField(BdIntSize.U32)]
		public uint PlayListOfs
		{
			get { return this.playListOfs; }
			set
			{
				this.playListOfs = value;
			}
		}

		[BdUIntField(BdIntSize.U32)]
		public uint PlayMarkOfs
		{
			get { return this.playMarkOfs; }
			set
			{
				this.playMarkOfs = value;
			}
		}

		[BdUIntField(BdIntSize.U32)]
		public uint ExtDataOfs
		{
			get { return this.extDataOfs; }
			set
			{
				this.extDataOfs = value;
			}
		}

		[BdByteArrayField]
		public byte[] ReservedForFutureUse
		{
			get { return this.reservedForFutureUse; }
			set { this.reservedForFutureUse = value; }
		}

		[BdUIntField(BdIntSize.U32)]
		public uint AppInfoLen
		{
			get { return this.appInfoLen; }
			set
			{
				this.appInfoLen = value;
				if (!object.ReferenceEquals(this.appInfoSeg, null))
				{
					this.appInfoSeg.Length = value;
				}
			}
		}
		[BdSubPartField(LengthIndicator="AppInfoLen")]
		public BdExtensionData AppInfoSeg
		{
			get { return this.appInfoSeg; }
			set { this.appInfoSeg = value; }
		}

		[BdUIntField(BdIntSize.U32, OffsetIndicator = "PlayListOfs", SkipIndicator = "playListSkip")]
		public uint PlayListLen
		{
			get { return this.playListSkip? 0 :this.playListLen; }
			set { 
				this.playListLen = value;
				if (!object.ReferenceEquals(this.playListSeg, null))
				{
					this.playListSeg.Length = value;
				}
			}
		}
		[BdSubPartField(LengthIndicator = "PlayListLen", SkipIndicator = "playListSkip")]
		public BdExtensionData PlayListSeg
		{
			get { return this.playListSkip? null :this.playListSeg; }
		}

		[BdUIntField(BdIntSize.U32, OffsetIndicator = "PlayMarkOfs", SkipIndicator = "playMarkSkip")]
		public uint PlayMarkLen
		{
			get { return this.playMarkSkip ? 0 : this.playMarkLen; }
			set
			{
				this.playMarkLen = value;
				if (!object.ReferenceEquals(this.playMarkSeg, null))
				{
					this.playMarkSeg.Length = value;
				}
			}
		}
		[BdSubPartField(LengthIndicator = "PlayMarkLen", SkipIndicator = "playMarkSkip")]
		public BdExtensionData PlayMarkSeg
		{
			get { return this.playMarkSkip ? null : this.playMarkSeg; }
		}

		[BdUIntField(BdIntSize.U32, OffsetIndicator = "ExtDataOfs", SkipIndicator = "extDataSkip")]
		public uint ExtDataLen
		{
			get { return this.extDataSkip ? 0: this.extDataLen; }
			set
			{
				this.extDataLen = value;
				if (!object.ReferenceEquals(this.extDataSeg, null))
				{
					this.extDataSeg.Length = value;
				}
			}
		}
		[BdSubPartField(LengthIndicator = "extDataLen", SkipIndicator = "extDataSkip")]
		public BdExtensionData ExtDataSeg
		{
			get { return this.extDataSkip ? null : this.extDataSeg; }
			set
			{
				this.extDataSeg = value;
				if (!object.ReferenceEquals(value, null))
				{
					this.extDataSkip = true;
				}
			}
		}

		public override string ToString()
		{
			return "测试文件结构：mpls";
		}
	}
}