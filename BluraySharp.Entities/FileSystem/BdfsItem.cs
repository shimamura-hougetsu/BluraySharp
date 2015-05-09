/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at BitBucket (https://bitbucket.org/subelf/bluraysharp)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace BluraySharp.FileSystem
{
	public abstract class BdfsItem : IBdfsItem
	{
		public virtual string Name
		{
			get;
			set;
		}

		public virtual FileSystemInfo DetailedInfo
		{
			get
			{
				return new FileInfo(this.GetFullPath());
			}
		}

		public IBdfsAttribute Attribute
		{
			get { return null; }
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

		IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public const string PathSplitter = @"\";
	}
}
