using System;
namespace BluraySharp.Common.BdPartFramework
{
	internal interface IBdFieldSeeker : IBdField
	{
		int Index { get; set; }
		int LowerBound { get; }
		int UpperBound { get; }
		ulong Offset { get; set; }
		bool IsOffsetSpecified { get; }
	}
}
