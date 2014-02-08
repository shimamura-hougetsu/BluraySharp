using System;
using BluraySharp.Common;
using BluraySharp.Architecture;

namespace BluraySharp.Playlist
{
	[BdComponent("PLAYLIST", "$number.mpls", 2000, true)]
	public interface IPlayList: IBdComponent
	{
		string MplsMarkX { get; }
		string MplsVerX { get; set; }

		BluraySharp.Playlist.IPlAppInfo ApplicationInfo { get; }
		BluraySharp.Playlist.IPlPlayItemList PlayItemList { get; }
		BluraySharp.Playlist.IPlMarkList MarkList { get; }
		BluraySharp.Common.BdExtensionData ExtensionDataX { get; set; }

		IPlAppInfo CreateAppInfo();
		IPlPlayItemList CreatePlayItemList();
		IPlMarkList CreateMarkList();
	}
}
