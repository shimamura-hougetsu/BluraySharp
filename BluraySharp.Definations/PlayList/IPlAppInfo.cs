using System;
using BluraySharp.Common;


namespace BluraySharp.PlayList
{
	public interface IPlAppInfo : IBdPart
	{
		BluraySharp.PlayList.PlPlaybackType PlaybackType { get; set; }
		ushort PlaybackCount { get; set; }

		BluraySharp.Common.BdUOMask UoMask { get; }

		bool AudioMixAppFlag { get; set; }
		bool LosslessMayBypassMixer { get; set; }
		bool RandomAccessFlag { get; set; }
	}
}