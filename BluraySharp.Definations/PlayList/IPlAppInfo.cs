using System;

namespace BluraySharp.Playlist
{
	public interface IPlAppInfo : IBdPart
	{
		BluraySharp.Playlist.PlPlaybackType PlaybackType { get; set; }
		ushort PlaybackCount { get; set; }

		BluraySharp.Common.BdUOMask UoMask { get; }

		bool AudioMixAppFlag { get; set; }
		bool LosslessMayBypassMixer { get; set; }
		bool RandomAccessFlag { get; set; }
	}
}