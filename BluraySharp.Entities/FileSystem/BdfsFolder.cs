using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.FileSystem
{
	public class BdfsFolder<T> : BdfsItem, IBdfsFolder<T> 
		where T : IBdfsItem
	{
		public override string Name
		{
			get
			{
				return base.Name;
			}
			set
			{
				base.Name = value;
			}
		}

		public override System.IO.FileSystemInfo DetailedInfo
		{
			get
			{
				return new System.IO.DirectoryInfo(this.GetFullPath());
			}
		}

		public void Detach(T fsObject)
		{
			BdfsItem tFsObj = fsObject as BdfsItem;

			if (object.ReferenceEquals(tFsObj, null))
			{
				//Invalid argument
				throw new ArgumentException("fsObject");
			}

			if (object.ReferenceEquals(tFsObj.Parent, this))
			{
				if (this.children.Remove(fsObject))
				{
					tFsObj.Parent = null;
				}
				else
				{
					//TODO: Failed; Cannot detach special child.
					throw new Exception();
				}
			}
		}

		public void Attach(T fsObject)
		{
			BdfsItem tFsObj = fsObject as BdfsItem;

			if (object.ReferenceEquals(tFsObj, null))
			{
				throw new ArgumentException("fsObject");
			}

			if (object.ReferenceEquals(tFsObj.Parent, this))
			{
				//Already attached to this.
				return;
			}
			else if (! object.ReferenceEquals(tFsObj.Parent, null))
			{
				//tFsObj Attached to other folder, detach it first.
				BdfsFolder<T> tOldParent = tFsObj.Parent as BdfsFolder<T>;

				if (object.ReferenceEquals(tOldParent, null))
				{
					//Parent folder type not matched.
					throw new ArgumentException();
				}

				tOldParent.Detach(fsObject);
			}

			tFsObj.Parent = this;
			this.children.Add(fsObject);
		}

		protected List<T> children = new List<T>();

		public override IEnumerable<IBdfsItem> Children
		{
			get
			{
				return (from iChild in this.children select iChild as IBdfsItem);
			}
		}
		
		public override IEnumerator<IBdfsItem> GetEnumerator()
		{
			foreach (T tChild in this.children)
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
