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

		[BdUIntField(BdIntSize.U32)]
		public uint PlayItemListOfs
		{
			get { return (this.playItemList == null ? 0 : this.playItemListOfs); }
			set
			{
				this.playItemList = 
					(this.playItemListOfs = value) > 0 ? new PlPlayItemList() : null;
			}
		}
		[BdUIntField(BdIntSize.U32)]
		public uint PlayMarkListOfs
		{
			get { return (this.playMarkList == null ? 0 : this.playMarkListOfs); }
			set
			{
				this.playMarkList =
					(this.playMarkListOfs = value) > 0 ? new PlPlayMarkList() : null;
			}
		}
		[BdUIntField(BdIntSize.U32)]
		public uint ExtensionDataOfs
		{
			get { return (this.extensionData == null ? 0 : this.playItemListOfs); }
			set
			{
				this.extensionData =
					(this.extensionDataOfs = value) > 0 ? new BdExtensionData() : null;
			}
		}

		[BdSubPartField]
		public IPlAppInfo AppInfo
		{
			get { return this.appInfo; }
		}

		[BdFieldOffset("PlayItemListOfs")]
		[BdSubPartField]
		public IPlPlayItemList PlayItemList
		{
			get { return this.playItemList; }
		}

		[BdFieldOffset("PlayMarkListOfs")]
		[BdSubPartField]
		public IPlPlayMarkList PlayMarkList
		{
			get { return this.playMarkList; }
		}

		[BdFieldOffset("ExtensionDataOfs")]
		[BdSubPartField]
		public BdExtensionData ExtensionData
		{
			get { return this.extensionData; }
			set { this.extensionData = value; }
		}

		#endregion BdPart

		public override string ToString()
		{
			return "PlayList";
		}
	}
}
