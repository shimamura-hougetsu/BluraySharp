using System.Collections;
using System.Collections.Generic;

namespace BluraySharp.Common
{
	public interface IBdList<T> : IBdList, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		T CreateNew();

		new T this[int index] { get; set; }

		new int Count { get; }

		void Insert(int index, T item);

		void RemoveAt(int index);

		int IndexOf(T item);
	}
}
