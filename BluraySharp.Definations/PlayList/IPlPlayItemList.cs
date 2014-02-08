using System;
using BluraySharp.Architecture;

namespace BluraySharp.Playlist
{
	public interface IPlPlayItemList : IBdPart
	{
		System.Collections.Generic.IList<BluraySharp.Playlist.IPlPlayItem> PlayItems { get; }
		System.Collections.Generic.IList<BluraySharp.Playlist.IPlSubPath> SubPaths { get; }

		IPlPlayItem CreatePlayItem();
		IPlSubPath CreateSubPath();
	}
}
