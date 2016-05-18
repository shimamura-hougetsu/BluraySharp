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
		public virtual IEnumerable<IBdfsItem> Children
		{
			get { return null; }
		}

		public virtual string Path
		{
			get { return null; }
		}

		public virtual string BackupPath
		{
			get { return null; }
		}

		public override string ToString()
		{
			if (string.IsNullOrWhiteSpace(this.Path))
			{
				return null;
			}
			else
			{
				return System.IO.Path.GetFileName(this.Path);
			}
		}

		public abstract void Rename(IBdfs fileSystem, string newName);
		public abstract void MoveTo(IBdfs fileSystem, string newPath);

		public virtual IEnumerator<IBdfsItem> GetEnumerator()
		{
			yield return this;
		}

		IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

	}
}
