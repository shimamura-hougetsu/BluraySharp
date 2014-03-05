using System;
using System.Collections.Generic;

namespace BluraySharp.Common.BdStandardPart
{
	public class BdPartList<T, I> : IBdList<I>
		where T : I, new()
	{
		public I CreateNew()
		{
			throw new NotImplementedException();
		}

		public I this[int index]
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public void Insert(I item, int index)
		{
			throw new NotImplementedException();
		}

		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		public int IndexOf(I item)
		{
			throw new NotImplementedException();
		}

		object IBdList.this[int index]
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public int LowerBound
		{
			get { throw new NotImplementedException(); }
		}

		public int UpperBound
		{
			get { throw new NotImplementedException(); }
		}

		public void CopyTo(Array array, int index)
		{
			throw new NotImplementedException();
		}

		public int Count
		{
			get { throw new NotImplementedException(); }
		}

		public bool IsSynchronized
		{
			get { throw new NotImplementedException(); }
		}

		public object SyncRoot
		{
			get { throw new NotImplementedException(); }
		}

		public System.Collections.IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public void Add(I item)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public bool Contains(I item)
		{
			throw new NotImplementedException();
		}

		public void CopyTo(I[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public bool IsReadOnly
		{
			get { throw new NotImplementedException(); }
		}

		public bool Remove(I item)
		{
			throw new NotImplementedException();
		}

		IEnumerator<I> IEnumerable<I>.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
