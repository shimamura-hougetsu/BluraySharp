using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;
using System;
using System.Diagnostics;
using System.Linq;

namespace BluraySharp.PlayList
{
	public class BdMoviePlayList : BdPart, IPlayList
	{
		#region MplsMark

		private const string MplsMarkConst = "MPLS";
		private string mplsMark = BdMoviePlayList.MplsMarkConst;

		[BdStringField(4, Common.BdCharacterCodingType.UTF8)]
		public string MplsMark
		{
			get { return this.mplsMark; }
			set
			{
				Debug.Assert(value == BdMoviePlayList.MplsMarkConst);
				this.mplsMark = value;
			}
		}

		#endregion

		#region MplsVer

		private static readonly string[] MplsVers = new string[] { "0100", "0200" };
		private string mplsVer = BdMoviePlayList.MplsVers[1];

		[BdStringField(4, Common.BdCharacterCodingType.UTF8)]
		public string MplsVer
		{
			get { return this.mplsVer; }
			set
			{
				Debug.Assert(BdMoviePlayList.MplsVers.Contains(value));
				this.mplsVer = value;
			}
		}

		#endregion

		#region PlayItemListOfs


		private bool playItemListSkip = false;
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

		private uint playItemListOfs = 0;

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

		#endregion

		#region PlayMarkListOfs

		private bool playMarkListSkip = false;
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

		private uint playMarkListOfs = 0;

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

		#endregion

		#region ExtensionDataOfs
		
		private bool extensionDataSkip = true;
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
		
		private uint extensionDataOfs = 0;

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

		#endregion

		#region ReserevedForFutureUse
		
		private byte[] reserevedForFutureUse = new byte[20];

		[BdByteArrayField]
		public byte[] ReserevedForFutureUse
		{
			get { return this.reserevedForFutureUse; }
		}

		#endregion

		#region AppInfo

		private PlAppInfo appInfo = new PlAppInfo();

		[BdSubPartField]
		public IPlAppInfo AppInfo
		{
			get { return this.appInfo; }
		}

		#endregion

		#region PlayItemList

		private PlPlayItemList playItemList = new PlPlayItemList();

		[BdSubPartField(SkipIndicator="PlayItemListSkip", OffsetIndicator="PlayItemListOfs")]
		public IPlPlayItemList PlayItemList
		{
			get { return this.playItemList; }
		}

		#endregion

		#region PlayMarkList

		private PlPlayMarkList playMarkList = new PlPlayMarkList();

		[BdSubPartField(SkipIndicator = "PlayMarkListSkip", OffsetIndicator = "PlayMarkListOfs")]
		public IPlPlayMarkList PlayMarkList
		{
			get { return this.playMarkList; }
		}

		#endregion

		#region ExtensionData

		private BdExtensionData extensionData = null;

		[BdSubPartField(SkipIndicator = "ExtensionDataSkip", OffsetIndicator = "ExtensionDataOfs")]
		public BdExtensionData ExtensionData
		{
			get { return this.extensionData; }
			set
			{
				this.ExtensionDataSkip = (this.extensionData = value).IsNull();
			}
		}

		#endregion

		public override string ToString()
		{
			return "Bluray MPLS(Movie Play List) file.";
		}
	}
}
