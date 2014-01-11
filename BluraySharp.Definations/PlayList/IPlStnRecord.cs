using System;
namespace BluraySharp.Playlist
{
	public interface IPlStnRecord : IBdObject
	{
		BluraySharp.Playlist.IPlStnRecordCodecInfo CodecInfo { get; }
		BluraySharp.Playlist.IPlStnRecordStreamInfo StreamInfo { get; }
	}
}
