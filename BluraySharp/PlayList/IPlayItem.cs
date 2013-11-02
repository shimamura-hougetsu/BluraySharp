using System;
using System.Collections.Generic;
using BluraySharp.Common;
namespace BluraySharp.PlayList
{
	public interface IPlayItem
	{
		byte StcId { get; set; }
		BdTime InTime { get; set; }
		BdTime OutTime { get; set; }

		IPlArrangingInfo ArrangingInfo { get; }
		IList<IPlClipInfo> AngleList { get; }
		void AddAngle(string codec, string id);
	}
}
