using System;
using BluraySharp.Common;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	[BdArrayEntry("PLAYLIST", "mpls", 2000, true)]
	public interface IPlayList: IBdArrayEntry
	{
		string MplsMark { get; }
		string MplsVer { get; set; }

		BluraySharp.PlayList.IPlAppInfo ApplicationInfo { get; }
		BluraySharp.PlayList.IPlPlayItemList PlayItemList { get; }
		BluraySharp.PlayList.IPlMarkList MarkList { get; }
		BluraySharp.Common.BdExtensionData ExtensionData { get; set; }
	}
}
