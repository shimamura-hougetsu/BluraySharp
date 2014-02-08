using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.FileSystem
{
	public abstract class BdfsItem : IBdfsItem
	{
		public virtual string Name
		{
			get;
			set;
		}

		public virtual System.IO.FileSystemInfo DetailedInfo
		{
			get
			{
				return new System.IO.FileInfo(this.GetFullPath());
			}
		}

		public IBdfsAttribute Attribute
		{
			get { throw new NotImplementedException(); }
		}

		public IBdfsItem Parent
		{
			get;
			set;
		}

		public virtual IEnumerable<IBdfsItem> Children
		{
			get { return null; }
		}

		public virtual string GetFullPath()
		{
			if (this.Parent == null)
			{
				//TODO: cannot determine the full path for a standalone file.
				throw new InvalidOperationException();
			}

			return this.Parent.GetFullPath() + this.Name;
		}

		public virtual string GetBackupPath()
		{
			if (this.Parent == null)
			{
				//TODO: cannot determine the backup path for a standalone file.
				throw new InvalidOperationException();
			}

			return this.Parent.GetBackupPath() + this.Name;
		}

		public override string ToString()
		{
			return this.Name;
		}

		public virtual IEnumerator<IBdfsItem> GetEnumerator()
		{
			yield return this;
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public const string PathSplitter = @"\";
	}
}
