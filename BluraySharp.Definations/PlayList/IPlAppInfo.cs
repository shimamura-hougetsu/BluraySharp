using System;
using BluraySharp.Common;
using BluraySharp.Common.BdStandardPart;


namespace BluraySharp.PlayList
{
	public interface IPlAppInfo : IBdPart
	{
		BluraySharp.PlayList.PlPlaybackType PlaybackType { get; set; }
		ushort PlaybackCount { get; set; }

		BdUOMask UoMask { get; }

		bool AudioMixAppFlag { get; set; }
		bool LosslessMayBypassMixer { get; set; }
		bool RandomAccessFlag { get; set; }
	}
}