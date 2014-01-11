using System;
namespace BluraySharp.Playlist
{
	public interface IPlPlayItemList : IBdObject
	{
		System.Collections.Generic.IList<BluraySharp.Playlist.IPlPlayItem> PlayItems { get; }
		System.Collections.Generic.IList<BluraySharp.Playlist.IPlSubPath> SubPaths { get; }
	}
}
