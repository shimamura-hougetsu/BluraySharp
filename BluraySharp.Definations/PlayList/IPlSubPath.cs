using System;
using BluraySharp.Architecture;

namespace BluraySharp.Playlist
{
	public interface IPlSubPath : IBdPart
	{
		System.Collections.Generic.IList<BluraySharp.Playlist.IPlPlayItem> PlayItems { get; }
		BluraySharp.Playlist.PlSubPathType Type { get; set; }

		IPlPlayItem CreateSubPlayItem();
	}
}
