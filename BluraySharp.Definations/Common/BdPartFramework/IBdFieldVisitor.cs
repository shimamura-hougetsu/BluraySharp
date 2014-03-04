using System;

namespace BluraySharp.Common.BdPartFramework
{
	internal interface IBdFieldVisitor : IBdFieldInfo
	{
		IBdFieldVisitor OffsetIndicator { get; }
		IBdFieldVisitor LengthIndicator { get; }
		object Value { get; set; }
	}
}
