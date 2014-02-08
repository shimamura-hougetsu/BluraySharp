using System;
using BluraySharp.Architecture;

namespace BluraySharp.Playlist
{
	public interface IPlStnRecord : IBdPart
	{
		BluraySharp.Playlist.IPlStnRecordCodecInfo CodecInfo { get; }
		BluraySharp.Playlist.IPlStnRecordStreamInfo StreamInfo { get; }
	}
}
