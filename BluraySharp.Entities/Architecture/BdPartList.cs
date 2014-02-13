﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Architecture
{
	public class BdPartList<T, I> : IBdList<I>
		where T : I, new()
		where I : IBdPart
	{
		private List<T> innerList = new List<T>();

		public int Count
		{
			get
			{
				return this.innerList.Count;
			}
		}

		public int MaxCount
		{
			get;
			private set;
		}

		public void Clear()
		{
			this.innerList.Clear();
		}

		public void CopyTo(I[] array, int arrayIndex)
		{
			this.innerList.ToArray().CopyTo(array, arrayIndex);
		}

		public bool Contains(I item)
		{
			T tItem = (T) item;
			if (tItem == null)
			{
				return false;
			}
			else
			{
				return this.innerList.Contains(tItem);
			}
		}

		public void Insert(I item)
		{
			T tItem = (T)item;
			if (tItem == null)
			{
				//Invalid value for List
				throw new ArgumentException("value");
			}
			else
			{
				this.innerList.Add(tItem);
			}
		}

		public bool Remove(I item)
		{
			T tItem = (T) item;
			if (tItem == null)
			{
				return false;
			}
			else
			{
				return this.innerList.Remove(tItem);
			}
		}

		public I this[int index]
		{
			get
			{
				return this.innerList[index];
			}
			set
			{
				T tItem = (T)value;
				if (tItem == null)
				{
					//Invalid value for List
					throw new ArgumentException("value");
				}
				else
				{
					this.innerList[index] = tItem;
				}
			}
		}

		public int IndexOf(I item)
		{
			T tItem = (T)item;
			if (tItem == null)
			{
				return -1;
			}
			else
			{
				return this.innerList.IndexOf(tItem);
			}
		}
		
		public void InsertAt(int index, I item)
		{
			T tItem = (T)item;
			if (tItem == null)
			{
				//Invalid value for List
				throw new ArgumentException("value");
			}
			else
			{
				this.innerList.Insert(index, tItem);
			}
		}

		public void RemoveAt(int index)
		{
			this.innerList.RemoveAt(index);
		}

		public I CreateNew()
		{
			return new T();
		}

		public IEnumerator<I> GetEnumerator()
		{
			foreach (I iItem in this.innerList)
			{
				yield return iItem;
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}