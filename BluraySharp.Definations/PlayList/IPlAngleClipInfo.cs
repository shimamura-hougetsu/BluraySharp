using System;
namespace BluraySharp.Playlist
{
	public interface IPlAngleClipInfo : IBdObject
	{
		string ClipCodec { get; set; }
		string ClipFilename { get; set; }
		string ToString();
	}
}
