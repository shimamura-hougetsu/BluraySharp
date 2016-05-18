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
	class BdfsNormal : IBdfs
	{
		public BdfsNormal(string root)
		{
			this.Root = root.TrimEnd(Path.DirectorySeparatorChar);
		}

		public bool IsFileExist(string name)
		{
			return File.Exists(GetFullNameOf(name));
		}

		public bool IsFolderExist(string name)
		{
			return Directory.Exists(GetFullNameOf(name));
		}

		public Stream OpenFile(string name, FileMode mode, FileAccess access)
		{
			return new FileStream(GetFullNameOf(name), mode, access);
		}

		public string Root { get; private set; }

		private string GetFullNameOf(string name)
		{
			return this.Root + Path.DirectorySeparatorChar + name;
		}
	}
}
