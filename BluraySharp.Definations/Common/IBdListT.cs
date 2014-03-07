using System.Collections;
using System.Collections.Generic;

namespace BluraySharp.Common
{
	public interface IBdList<T> : ICollection<T>, IEnumerable<T>, IEnumerable
	{
		T CreateNew();

		T this[int index] { get; set; }

		void Insert(int index, T item);

		void RemoveAt(int index);

		int IndexOf(T item);
	}
}
