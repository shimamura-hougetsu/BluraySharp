using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;
using System;
using System.Diagnostics;
using System.Linq;

namespace BluraySharp.PlayList
{
	public class PlayList : BdPart, IPlayList
	{
		#region Private Data Fields

		private const string MplsMarkConst = "MPLS";
		private string mplsMark = PlayList.MplsMarkConst;

		private static readonly string[] MplsVers = new string[] {"0100", "0200"};
		private string mplsVer = PlayList.MplsVers[1];

		private uint playItemListOfs = 0;
		private uint playMarkListOfs = 0;
		private uint extensionDataOfs = 0;

		private byte[] reserevedForFutureUse = new byte[20];

		private PlAppInfo appInfo = new PlAppInfo();
		private PlPlayItemList playItemList = new PlPlayItemList();
		private PlPlayMarkList playMarkList = new PlPlayMarkList();
		private BdExtensionData extensionData = null;

		//skip flags
		private bool playItemListSkip = false;
		private bool playMarkListSkip = false;
		private bool extensionDataSkip = true;

		#endregion Private Data Fields

		#region BdPart

		[BdStringField(4, Common.BdCharacterCodingType.UTF8)]
		public string MplsMark
		{
			get { return this.mplsMark; }
			set
			{
				Debug.Assert(value == PlayList.MplsMarkConst);
				this.mplsMark = value;
			}
		}
		[BdStringField(4, Common.BdCharacterCodingType.UTF8)]
		public string MplsVer
		{
			get { return this.mplsVer; }
			set
			{
				Debug.Assert(PlayList.MplsVers.Contains(value));
				this.mplsVer = value;
			}
		}

		public bool PlayItemListSkip
		{
			get { return this.playItemListSkip; }
			set
			{
				if (this.playItemListSkip != value)
				{
					if (this.playItemListSkip = value)
					{
						this.playItemList = null;
						this.playItemListOfs = 0;
					}
					else
					{
						this.playItemList = new PlPlayItemList();
					}
				}
			}
		}
		[BdUIntField(BdIntSize.U32)]
		public uint PlayItemListOfs
		{
			get { return this.playItemListOfs; }
			set
			{
				this.PlayItemListSkip =
					((this.playItemListOfs = value) == 0);
			}
		}

		public bool PlayMarkListSkip
		{
			get { return this.playMarkListSkip; }
			set
			{
				if (this.playMarkListSkip != value)
				{
					if (this.playMarkListSkip = value)
					{
						this.playMarkList = null;
						this.playMarkListOfs = 0;
					}
					else
					{
						this.playMarkList = new PlPlayMarkList();
					}
				}
			}
		}
		[BdUIntField(BdIntSize.U32)]
		public uint PlayMarkListOfs
		{
			get { return this.playMarkListOfs; }
			set
			{
				this.PlayMarkListSkip =
					((this.playMarkListOfs = value) == 0);
			}
		}

		public bool ExtensionDataSkip
		{
			get { return this.extensionDataSkip; }
			set
			{
				if (this.extensionDataSkip != value)
				{
					if (this.extensionDataSkip = value)
					{
						this.extensionData = null;
						this.extensionDataOfs = 0;
					}
					else
					{
						this.extensionData = new BdExtensionData();
					}
				}
			}
		}
		[BdUIntField(BdIntSize.U32)]
		public uint ExtensionDataOfs
		{
			get { return this.extensionDataOfs; }
			set
			{
				this.ExtensionDataSkip =
					((this.extensionDataOfs = value) == 0);
			}
		}

		[BdByteArrayField]
		public byte[] ReserevedForFutureUse
		{
			get { return this.reserevedForFutureUse; }
		}

		[BdSubPartField]
		public IPlAppInfo AppInfo
		{
			get { return this.appInfo; }
		}

		[BdSubPartField(SkipIndicator="PlayItemListSkip", OffsetIndicator="PlayItemListOfs")]
		public IPlPlayItemList PlayItemList
		{
			get { return this.playItemList; }
		}

		[BdSubPartField(SkipIndicator = "PlayMarkListSkip", OffsetIndicator = "PlayMarkListOfs")]
		public IPlPlayMarkList PlayMarkList
		{
			get { return this.playMarkList; }
		}

		[BdSubPartField(SkipIndicator = "ExtensionDataSkip", OffsetIndicator = "ExtensionDataOfs")]
		public BdExtensionData ExtensionData
		{
			get { return this.extensionData; }
			set
			{
				this.ExtensionDataSkip = (this.extensionData = value).IsNull();
			}
		}

		#endregion BdPart

		public override string ToString()
		{
			return "PlayList";
		}
	}
}
