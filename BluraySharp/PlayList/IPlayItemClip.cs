using System;
using System.Collections.Generic;
namespace BluraySharp.PlayList
{
	interface IPlayItemClip
	{
		PlaybackArrangingFlags ArrangingFlags { get; }
		string ClipCodec { get; set; }
		string ClipId { get; set; }
		BdTime InTime { get; }
		IList<PlaybackAngle> MultiAngleList { get; }
		BdTime OutTime { get; }
		byte StcId { get; set; }
	}
}
