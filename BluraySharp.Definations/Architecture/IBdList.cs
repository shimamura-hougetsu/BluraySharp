using System.Collections;
using System.Collections.Generic;

namespace BluraySharp.Architecture
{
	public interface IBdList<T> : IEnumerable<T>, IEnumerable
	{
		int Count { get; }
		int MaxCount { get; }

		void Clear();
		void CopyTo(T[] array, int arrayIndex);

		bool Contains(T item);

		void Insert(T item);
		bool Remove(T item);

		T this[int index] { get; set; }
		int IndexOf(T item);

		void InsertAt(int index, T item);
		void RemoveAt(int index);

		T CreateNew();
	}
}
