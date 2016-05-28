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
using System.IO;
using BluraySharp.Common;

namespace BluraySharp.FileSystem
{
	public class BdfsStandaloneFile<T> : BdfsEntryFile<T>, IBdfsEntryFile<T>
		where T : class, IBdmvEntry
	{
		private class InstantFs : BdfsBase
		{
			public override IBdfsBdmvRoot BdmvFolder
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public override void CreateFolder(string path)
			{
				throw new NotImplementedException();
			}

			public override bool IsFileExisted(string path)
			{
				return File.Exists(path);
			}

			public override bool IsFolderExisted(string path)
			{
				return Directory.Exists(path);
			}

			public override void Move(string srcPath, string dstPath)
			{
				throw new NotImplementedException();
			}

			public override Stream OpenFile(string path, FileMode mode, FileAccess access)
			{
				return new FileStream(path, mode, access);
			}

			public override void Reload(string path)
			{
				throw new NotImplementedException();
			}
		}

		private static InstantFs ifs = new InstantFs();

		public BdfsStandaloneFile(string path)
			: base(ifs, path, null)
		{
		}
	}
}
