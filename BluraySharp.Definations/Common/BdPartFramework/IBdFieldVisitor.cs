using System;

namespace BluraySharp.Common.BdPartFramework
{
	internal interface IBdFieldVisitor : IBdFieldInfo
	{
		IBdFieldVisitor OffsetIndicator { get; }
		IBdFieldVisitor LengthIndicator { get; }
		IBdFieldVisitor SkipIndicator { get; }
		object Value { get; set; }
	}
}
