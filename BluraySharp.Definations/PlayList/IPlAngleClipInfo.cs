using System;
namespace BluraySharp.Playlist
{
	public interface IPlAngleClipInfo : IBdRawSerializable
	{
		string ClipCodec { get; set; }
		string ClipFilename { get; set; }
		string ToString();
	}
}
