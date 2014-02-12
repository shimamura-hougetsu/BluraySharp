using System.Collections.Generic;
using BluraySharp.Architecture;
using BluraySharp.Common;


namespace BluraySharp.PlayList
{
	public interface IPlPlayItem : IBdPart
	{
		byte StcId { get; set; }
		BdTime InTime { get; set; }
		BdTime OutTime { get; set; }

		BdConnectionCondition ConnectionCondition { get; set; }
		bool IsMultiAngle { get; set; }

		IList<IPlAngleClipInfo> AngleList { get; }

		IPlAngleClipInfo CreateAngleClipInfo();
	}
}
