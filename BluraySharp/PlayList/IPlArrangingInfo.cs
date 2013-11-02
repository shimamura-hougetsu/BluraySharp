using System;

namespace BluraySharp.PlayList
{
	public interface IPlArrangingInfo : IBdRawSerializable
	{
		BluraySharp.Common.BdConnectionCondition ConnectionCondition { get; set; }
		bool IsMultiAngle { get; set; }
	}
}
