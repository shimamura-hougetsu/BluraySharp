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
		private bool playItemListSkip = false;
		private uint playMarkListOfs = 0;
		private bool playMarkListSkip = false;
		private uint extensionDataOfs = 0;
		private bool extensionDataSkip = true;

		private byte[] reserevedForFutureUse = new byte[20];

		private uint appInfoLen = 0;
		private PlAppInfo appInfo = new PlAppInfo();

		private uint playItemListLen = 0;
		private PlPlayItemList playItemList = new PlPlayItemList();

		private uint playMarkListLen = 0;
		private PlPlayMarkList playMarkList = new PlPlayMarkList();

		private uint extensionDataLen = 0;
		private BdExtensionData extensionData = null;

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
						this.playItemListLen = 0;
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
			get { return (this.PlayItemListSkip ? 0 : this.playItemListOfs); }
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
						this.playMarkListLen = 0;
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
			get { return (this.PlayMarkListSkip ? 0 : this.playMarkListOfs); }
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
						this.extensionDataLen = 0;
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
			get { return (this.ExtensionDataSkip ? 0 : this.extensionDataOfs); }
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

		[BdSubPartField]
		public IPlPlayItemList PlayItemList
		{
			get { return this.playItemList; }
		}

		[BdSubPartField]
		public IPlPlayMarkList PlayMarkList
		{
			get { return this.playMarkList; }
		}

		[BdSubPartField]
		public BdExtensionData ExtensionData
		{
			get { return this.extensionData; }
			set
			{
				this.ExtensionDataSkip = (this.extensionData = value).RefEquals(null);
			}
		}

		#endregion BdPart

		public override string ToString()
		{
			return "PlayList";
		}
	}
}
