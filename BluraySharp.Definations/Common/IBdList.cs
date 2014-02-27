using System;
using System.Collections;

namespace BluraySharp.Common
{
	public interface IBdList : ICollection, IEnumerable
	{
		int LowerBound { get; }
		int UpperBound { get; }
	}
}
