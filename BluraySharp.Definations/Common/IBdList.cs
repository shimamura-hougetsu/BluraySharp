using System;
using System.Collections;

namespace BluraySharp.Common
{
	public interface IBdList : ICollection, IEnumerable
	{
		object this[int index] { get; set; }
		int LowerBound { get; }
		int UpperBound { get; }
	}
}
