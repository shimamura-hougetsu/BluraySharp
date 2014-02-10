using System;
using BluraySharp.Architecture;

namespace BluraySharp.Playlist
{
	public interface IPlAngleClipInfo : IBdPart
	{
		string ClipCodec { get; set; }
		uint ClipId { get; set; }
		string ToString();
	}
}
