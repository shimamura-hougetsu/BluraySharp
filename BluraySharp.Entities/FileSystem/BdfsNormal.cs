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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BluraySharp.FileSystem
{
	class BdfsNormal : BdfsBase
	{
		public BdfsNormal(string rootPath)
		{
			this.RootPath = rootPath.TrimEnd(Path.DirectorySeparatorChar);
		}
		
		public string RootPath { get; private set; }

		public override IBdfsBdmvRoot BdmvFolder
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		private string GetFullNameOf(string path)
		{
			return this.RootPath + Path.DirectorySeparatorChar + path;
		}

		public override Stream OpenFile(string path, FileMode mode, FileAccess access)
		{
			return new FileStream(GetFullNameOf(path), mode, access);
		}

		public override bool IsFileExisted(string path)
		{
			return File.Exists(GetFullNameOf(path));
		}

		public override bool IsFolderExisted(string path)
		{
			return Directory.Exists(GetFullNameOf(path));
		}


		public override void CreateFolder(string path)
		{
			Directory.CreateDirectory(GetFullNameOf(path));
		}

		public override void Move(string srcPath, string dstPath)
		{
			Directory.Move(GetFullNameOf(srcPath), GetFullNameOf(dstPath));
		}

		public override void Reload(string path)
		{
			//TODO:
			return;
		}
	}
}
