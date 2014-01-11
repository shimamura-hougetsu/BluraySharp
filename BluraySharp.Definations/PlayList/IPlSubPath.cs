using System;
namespace BluraySharp.Playlist
{
	public interface IPlSubPath : IBdObject
	{
		System.Collections.Generic.IList<BluraySharp.Playlist.IPlPlayItem> PlayItems { get; }
		BluraySharp.Playlist.PlSubPathType Type { get; set; }

		IPlPlayItem CreateSubPlayItem();
	}
}
