using System.Collections;
using System.Collections.Generic;

namespace BluraySharp.Common
{
	public interface IBdList<T> : IBdList, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		T CreateNew();

		T this[int index] { get; set; }

		void Insert(T item, int index);

		void RemoveAt(int index);

		int IndexOf(T item);
	}
}
