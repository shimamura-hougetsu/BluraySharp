﻿using System;
namespace BluraySharp.Playlist
{
	public interface IPlayList: IBdObject
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
