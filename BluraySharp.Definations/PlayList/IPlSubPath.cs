using System;
namespace BluraySharp.Playlist
{
	public interface IPlSubPath : IBdRawSerializable
	{
		System.Collections.Generic.IList<BluraySharp.Playlist.IPlPlayItem> PlayItems { get; }
		BluraySharp.Playlist.PlSubPathType Type { get; set; }
	}
}
