using System;

namespace BluraySharp.Common.BdPartFramework
{
	internal interface IBdFieldTraverser : IBdFieldVisitor
	{
		int Index { get; set; }
		int LowerBound { get; }
		int UpperBound { get; }

		IBdFieldVisitor ScopeIndicator { get; }
	}
}
