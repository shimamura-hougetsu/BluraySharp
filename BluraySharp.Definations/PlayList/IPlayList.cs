using System;
using BluraySharp.Common;
using BluraySharp.FileSystem;

namespace BluraySharp.PlayList
{
	[BdArrayComponent("PLAYLIST", "mpls", 2000, true)]
	public interface IPlayList: IBdArrayComponent
	{
		string MplsMark { get; }
		string MplsVer { get; set; }

		BluraySharp.PlayList.IPlAppInfo AppInfo { get; }
		BluraySharp.PlayList.IPlPlayItemList PlayItemList { get; }
		BluraySharp.PlayList.IPlPlayMarkList PlayMarkList { get; }
		BluraySharp.Common.BdStandardPart.BdExtensionData ExtensionData { get; set; }
	}
}
