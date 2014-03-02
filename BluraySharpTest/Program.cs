using System;
using System.IO;
using BluraySharp;
using BluraySharp.PlayList;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Diagnostics;

namespace BluraySharpTest
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			string tFilePath = @"C:\StoreBase\_Temp\[BDMV][120926] 超訳百人一首 うた恋い。1\[ANZX6141] UTAKOI_1\BDMV\PLAYLIST\00000.mpls";
			//string tFilePath = @"C:\Users\Subelf.J\Documents\stillinf-norand.mpls";


			//using (FileStream tFileStream = new FileStream(tFilePath, FileMode.Open))
			//{
			//    BdmvContext tContext = new BdmvContext();
			//    IPlayList tMpls = tContext.OpenComponentFile<IPlayList>(tFileStream);

			//    System.Diagnostics.Debug.WriteLine(
			//            tMpls.PlayItemList.PlayItems[0].ConnectionCondition.ToStringLocalized()
			//        );

			//    tMpls.ToString();
			//}
		}

		[DebuggerTypeProxy(typeof(FF<>.FfUserFriendView))]
		[DebuggerDisplay("Count = {Count}")]
		class FF<T> : IList<T>, IList
		{
			private List<T> innerList = new List<T>();

			public int IndexOf(T item)
			{
				return this.innerList.IndexOf(item) + 1;
			}

			public void Insert(int index, T item)
			{
				this.innerList.Insert(index - 1, item);
			}

			public void RemoveAt(int index)
			{
				this.innerList.RemoveAt(index - 1);
			}

			public T this[int index]
			{
				get
				{
					return this.innerList[index - 1];
				}
				set
				{
					this.innerList[index - 1] = value;
				}
			}

			public void Add(T item)
			{
				this.innerList.Add(item);				
			}

			public void Clear()
			{
				this.innerList.Clear();
			}

			public bool Contains(T item)
			{
				return this.innerList.Contains(item);
			}

			public void CopyTo(T[] array, int arrayIndex)
			{
				this.innerList.CopyTo(array, arrayIndex);
			}

			public int Count
			{
				get
				{
					return this.innerList.Count;
				}
			}

			public bool IsReadOnly
			{
				get
				{
					return (this.innerList as ICollection<T>).IsReadOnly;
				}
			}

			public bool Remove(T item)
			{
				return this.innerList.Remove(item);
			}

			public IEnumerator<T> GetEnumerator()
			{
				return this.innerList.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return (this.innerList as IEnumerable).GetEnumerator();
			}

			private IList InnerIList { get { return this.innerList; } }

			int IList.Add(object value)
			{
				return this.InnerIList.Add(value) + 1;
			}

			void IList.Clear()
			{
				this.InnerIList.Clear();
			}

			bool IList.Contains(object value)
			{
				return this.InnerIList.Contains(value);
			}

			int IList.IndexOf(object value)
			{
				return this.InnerIList.IndexOf(value) + 1;
			}

			void IList.Insert(int index, object value)
			{
				this.InnerIList.Insert(index - 1, value);
			}

			bool IList.IsFixedSize
			{
				get
				{
					return this.InnerIList.IsFixedSize;
				}
			}

			bool IList.IsReadOnly
			{
				get
				{
					return this.InnerIList.IsReadOnly;
				}
			}

			void IList.Remove(object value)
			{
				this.InnerIList.Remove(value);
			}

			void IList.RemoveAt(int index)
			{
				this.InnerIList.Remove(index - 1);
			}

			object IList.this[int index]
			{
				get
				{
					return this.InnerIList[index - 1];
				}
				set
				{
					this.InnerIList[index - 1] = value;
				}
			}

			void ICollection.CopyTo(Array array, int index)
			{
				this.InnerIList.CopyTo(array, index - 1);
			}

			int ICollection.Count
			{
				get
				{
					return this.InnerIList.Count;
				}
			}

			bool ICollection.IsSynchronized
			{
				get
				{
					return this.InnerIList.IsSynchronized;
				}
			}

			object ICollection.SyncRoot
			{
				get
				{
					return this.InnerIList.SyncRoot;
				}
			}

			internal class FfUserFriendView
			{
				//private Dictionary<int, T> values;
				public FfUserFriendView(FF<T> list)
				{
					this.Keys = Array.CreateInstance(typeof(T), new int[] { list.Count } ,  new int[] { 1 });
					for (int i = 0; i < list.Count; ++i)
					{
						this.Keys.SetValue(list[i + 1], i + 1);
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
}
