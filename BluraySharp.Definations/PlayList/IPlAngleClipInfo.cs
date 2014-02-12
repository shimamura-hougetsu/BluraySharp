using System;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public interface IPlAngleClipInfo : IBdPart
	{
		string ClipCodec { get; set; }
		uint ClipId { get; set; }
		string ToString();
	}
}
