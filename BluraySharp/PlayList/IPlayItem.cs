using System;
using System.Collections.Generic;
using BluraySharp.Common;
namespace BluraySharp.PlayList
{
	interface IPlayItem
	{
		byte StcId { get; set; }
		BdTime InTime { get; set; }
		BdTime OutTime { get; set; }

		ArrangingInfo ArrangingInfo { get; }
		IList<IClipReferance> AngleList { get; }
		void AddAngle(string codec, string id);
	}
}
