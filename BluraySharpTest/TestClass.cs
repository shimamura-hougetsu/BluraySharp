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
				this.PlayListSkip = ((this.playListOfs = value) == 0);
			}
		}

		[BdUIntField(BdIntSize.U32)]
		public uint PlayMarkOfs
		{
			get { return this.playMarkOfs; }
			set
			{
				this.playMarkSkip = ((this.playMarkOfs = value) == 0);
			}
		}

		[BdUIntField(BdIntSize.U32)]
		public uint ExtDataOfs
		{
			get { return this.extDataOfs; }
			set
			{
				this.extDataSkip = ((this.extDataOfs = value) == 0);
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
		}

		[BdUIntField(BdIntSize.U32, OffsetIndicator = "PlayListOfs", SkipIndicator = "PlayListSkip")]
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
		[BdSubPartField(LengthIndicator = "PlayListLen", SkipIndicator = "PlayListSkip")]
		public BdExtensionData PlayListSeg
		{
			get { return this.playListSkip? null :this.playListSeg; }
		}

		[BdUIntField(BdIntSize.U32, OffsetIndicator = "PlayMarkOfs", SkipIndicator = "PlayMarkSkip")]
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
		[BdSubPartField(LengthIndicator = "PlayMarkLen", SkipIndicator = "PlayMarkSkip")]
		public BdExtensionData PlayMarkSeg
		{
			get { return this.playMarkSkip ? null : this.playMarkSeg; }
		}

		[BdUIntField(BdIntSize.U32, OffsetIndicator = "ExtDataOfs", SkipIndicator = "ExtDataSkip")]
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
		[BdSubPartField(LengthIndicator = "ExtDataLen", SkipIndicator = "ExtDataSkip")]
		public BdExtensionData ExtDataSeg
		{
			get { return this.extDataSkip ? null : this.extDataSeg; }
			set
			{
				this.extDataSeg = value;
				this.ExtDataSkip = object.ReferenceEquals(this.extDataSeg, null);
			}
		}

		private bool playListSkip = false;
		private bool playMarkSkip = false;
		private bool extDataSkip = true;

		public bool PlayListSkip
		{
			get { return this.playListSkip; }
			set {
				if (this.playListSkip != value)
				{
					if (this.playListSkip = value)
					{
						this.playListOfs = 0;
						this.playListLen = 0;
						this.playListSeg = null;
					}
					else
					{
						this.playListSeg = new BdExtensionData();
					}
				}
			}
		}
		public bool PlayMarkSkip
		{
			get { return this.playMarkSkip; }
			set
			{
				if (this.playMarkSkip != value)
				{
					if (this.playMarkSkip = value)
					{
						this.playMarkOfs = 0;
						this.playMarkLen = 0;
						this.playMarkSeg = null;
					}
					else
					{
						this.playMarkSeg = new BdExtensionData();
					}
				}
			}
		}
		public bool ExtDataSkip
		{
			get { return this.extDataSkip; }
			set
			{
				if (this.extDataSkip != value)
				{
					if (this.extDataSkip = value)
					{
						this.extDataOfs = 0;
						this.extDataLen = 0;
						this.extDataSeg = null;
					}
					else
					{
						this.extDataSeg = new BdExtensionData();
					}
				}
			}
		}

		public override string ToString()
		{
			return "测试文件结构：mpls";
		}
	}
}