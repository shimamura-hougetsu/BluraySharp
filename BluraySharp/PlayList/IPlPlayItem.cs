using System.Collections.Generic;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlPlayItem : IBdRawSerializable
	{
		byte StcId { get; set; }
		BdTime InTime { get; set; }
		BdTime OutTime { get; set; }

		IPlArrangingInfo ArrangingInfo { get; }
		IList<PlAngleClipInfo> AngleList { get; }
	}
}
