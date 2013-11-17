using System.Collections.Generic;
using BluraySharp.Common;

namespace BluraySharp.Playlist
{
	public interface IPlPlayItem : IBdRawSerializable
	{
		byte StcId { get; set; }
		BdTime InTime { get; set; }
		BdTime OutTime { get; set; }

		BdConnectionCondition ConnectionCondition { get; set; }
		bool IsMultiAngle { get; set; }

		IList<PlAngleClipInfo> AngleList { get; }
	}
}
