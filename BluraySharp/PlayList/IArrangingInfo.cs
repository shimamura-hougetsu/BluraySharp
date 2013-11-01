using System;
namespace BluraySharp.PlayList
{
	interface IArrangingInfo
	{
		BluraySharp.Common.ConjunctionType ConjunctionType { get; set; }
		bool IsMultiAngle { get; set; }
	}
}
