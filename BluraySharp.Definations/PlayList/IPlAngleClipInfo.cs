using System;
using BluraySharp.Architecture;

namespace BluraySharp.Playlist
{
	public interface IPlAngleClipInfo : IBdPart
	{
		string ClipCodec { get; set; }
		string ClipFilename { get; set; }
		string ToString();
	}
}
