using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.FileSystem
{
	public class BdfsFolder<T> : BdfsItem, IBdfsFolder<T> 
		where T : BdfsItem
	{
		public override System.IO.FileSystemInfo DetailedInfo
		{
			get
			{
				return new System.IO.DirectoryInfo(this.GetFullPath());
			}
		}

		public void Detach(T fsObject)
		{
			if (object.ReferenceEquals(fsObject.Parent, this))
			{
				fsObject.Parent = null;
			}

			this.children.Remove(fsObject);
		}

		public void Attach(T fsObject)
		{
			if(object.ReferenceEquals(fsObject, null))
			{
				throw new ArgumentNullException("fsObject");
			}

			if(!object.ReferenceEquals(fsObject.Parent, null))
			{
				BdfsFolder<T> tOldParent = this.Parent as BdfsFolder<T>;

				if (object.ReferenceEquals(tOldParent, null))
				{
					//Parent folder type not matched.
					throw new ArgumentException();
				}

				tOldParent.Detach(fsObject);
			}

			fsObject.Parent = this;
			this.children.Add(fsObject);
		}

		private List<T> children = new List<T>();

		public override IEnumerable<IBdfsItem> Children
		{
			get
			{
				return base.Children;
			}
		}

		public override IEnumerator<IBdfsItem> GetEnumerator()
		{
			foreach(T tChild in this.children)
			{
				foreach (T tLeafChild in tChild)
				{
					yield return tLeafChild;
				}
			}
		}

		public override string GetFullPath()
		{
			return this.Parent.GetFullPath() + this.Name + BdfsItem.PathSplitter;
		}

		public override string GetBackupPath()
		{
			return this.Parent.GetBackupPath() + this.Name + BdfsItem.PathSplitter;
		}
	}
}
