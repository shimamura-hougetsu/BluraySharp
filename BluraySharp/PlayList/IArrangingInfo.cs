using System;
namespace BluraySharp.PlayList
{
	interface IArrangingInfo
	{
		BluraySharp.Common.BdConnectionCondition ConjunctionType { get; set; }
		bool IsMultiAngle { get; set; }
	}
}
