using System;
namespace BluraySharp.Playlist
{
	public interface IPlStnRecord : IBdRawSerializable
	{
		BluraySharp.Playlist.IPlStnRecordCodecInfo CodecInfo { get; }
		BluraySharp.Playlist.IPlStnRecordStreamInfo StreamInfo { get; }
	}
}
