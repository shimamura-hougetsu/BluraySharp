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
	class BdfsUdf : IBdfs
	{
		public bool IsFileExist(string name)
		{
			throw new NotImplementedException();
		}

		public bool IsFolderExist(string name)
		{
			throw new NotImplementedException();
		}

		public Stream OpenFile(string name, FileMode mode, FileAccess access)
		{
			throw new NotImplementedException();
		}
	}
}
