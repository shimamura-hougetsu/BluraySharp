using System.Collections.Generic;
using BluraySharp.Architecture;
using BluraySharp.Common;


namespace BluraySharp.PlayList
{
	public interface IPlPlayItemInfo : IBdPart
	{
		byte StcId { get; set; }
		BdTime InTime { get; set; }
		BdTime OutTime { get; set; }

		BdConnectionCondition ConnectionCondition { get; set; }
		bool IsMultiAngle { get; set; }

		IBdList<IPlAngleClipInfo> AngleList { get; }
	}
}
