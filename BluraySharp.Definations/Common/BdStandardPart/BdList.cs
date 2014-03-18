using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace BluraySharp.Common.BdStandardPart
{
	[DebuggerTypeProxy(typeof(BdList<,>.UserFriendView))]
	[DebuggerDisplay("Count = {Count}")]
	public class BdList<T, I> : IBdList<I>
		where T : I, new()
	{
		public BdList()
			: this(0)
		{
		}

		public BdList(IEnumerable<I> collection)
			: this(0, collection)
		{
		}

		public BdList(int lowerBound)
			: this(lowerBound, -1)
		{
		}

		public BdList(int lowerBound, IEnumerable<I> collection)
			: this(lowerBound, -1, collection)
		{
		}

		public BdList(int lowerBound, int capacity)
		{
			this.lowerBound = lowerBound;
			if (capacity > 0)
			{
				this.capacity = capacity;
				this.innerList = new List<I>(capacity);
			}
			else
			{
				this.capacity = -1;
				this.innerList = new List<I>();
			}
		}

		public BdList(int lowerBound, int capacity, IEnumerable<I> collection)
		{
			this.lowerBound = lowerBound;

			if (capacity > 0)
			{
				this.capacity = capacity;
				List<I> tList = new List<I>(collection);
				if (tList.Count > capacity)
				{
					throw new IndexOutOfRangeException();
				}
				this.innerList = tList;
			}
			else
			{
				this.capacity = -1;
				this.innerList = new List<I>(collection);
			}
		}

		private List<I> innerList;
		private int lowerBound;
		private int capacity;

		public I CreateNew()
		{
			return new T();
		}

		public I this[int index]
		{
			get
			{
				return this.innerList[index - this.lowerBound];
			}
			set
			{
				this.innerList[index - this.lowerBound] = value;
			}
		}

		public void Insert(int index, I item)
		{
			if (this.Count == this.Capacity)
			{
				//TODO: Out of capacity.
				throw new IndexOutOfRangeException();
			}

			this.innerList.Insert(index - this.lowerBound, item);
		}

		public void RemoveAt(int index)
		{
			this.innerList.RemoveAt(index - this.lowerBound);
		}

		public int IndexOf(I item)
		{
			return this.IndexOf(item) - this.lowerBound;
		}

		private IList InnerList
		{
			get { return this.innerList as IList; }
		}

		object IBdList.this[int index]
		{
			get
			{
				return this.InnerList[index - this.lowerBound];
			}
			set
			{
				I tItem = (I) value;
				this.InnerList[index - this.lowerBound] = tItem;
			}
		}

		public int LowerBound
		{
			get { return this.lowerBound; }
		}

		public int UpperBound
		{
			get { return this.lowerBound + this.Count; }
		}

		public int Count
		{
			get { return this.InnerList.Count; }
		}

		public int Capacity
		{
			get { return this.capacity; }
		}

		public void Add(I item)
		{
			if(this.Count == this.Capacity)
			{
				//TODO: Out of capacity.
				throw new IndexOutOfRangeException();
			}

			this.innerList.Add(item);
		}

		public void Clear()
		{
			this.innerList.Clear();
		}

		public bool Remove(I item)
		{
			return this.innerList.Remove(item);
		}

		IEnumerator<I> IEnumerable<I>.GetEnumerator()
		{
			return this.innerList.GetEnumerator();
		}

		public bool Contains(I item)
		{
			return this.InnerList.Contains(item);
		}

		public void CopyTo(I[] array, int arrayIndex)
		{
			this.InnerList.CopyTo(array, arrayIndex);
		}

		public bool IsReadOnly
		{
			get { return this.InnerList.IsReadOnly; }
		}

		public void CopyTo(Array array, int index)
		{
			this.InnerList.CopyTo(array, index);
		}

		public bool IsSynchronized
		{
			get { return this.InnerList.IsSynchronized; }
		}

		public object SyncRoot
		{
			get { return this.InnerList.SyncRoot; }
		}

		public System.Collections.IEnumerator GetEnumerator()
		{
			return this.InnerList.GetEnumerator();
		}


		internal class UserFriendView
		{
			//private Dictionary<int, T> values;
			public UserFriendView(BdList<T, I> list)
			{
				this.Keys = Array.CreateInstance(typeof(T), new int[] { list.Count }, new int[] { list.LowerBound });
				for (int i = list.LowerBound; i < list.UpperBound; ++i)
				{
					this.Keys.SetValue(list[i], i);
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public Array Keys
			{
				get;
				private set;
			}
		}
	}
}
