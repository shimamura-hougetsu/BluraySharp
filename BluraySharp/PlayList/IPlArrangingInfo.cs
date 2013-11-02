using System;
namespace BluraySharp.PlayList
{
	public interface IPlArrangingInfo
	{
		BluraySharp.Common.BdConnectionCondition ConjunctionType { get; set; }
		bool IsMultiAngle { get; set; }
	}
}
