using System.Collections.Generic;
using BluraySharp.Common;

namespace BluraySharp.Playlist
{
	public interface IPlPlayItem : IBdRawSerializable
	{
		byte StcId { get; set; }
		BdTime InTime { get; set; }
		BdTime OutTime { get; set; }

		IPlArrangingOption ArrangingOption { get; }
		IList<PlAngleClipInfo> AngleList { get; }
	}
}
