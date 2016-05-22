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
	/// <summary>
	/// Not implemented yet.
	/// </summary>
	class BdfsUdf : BdfsBase
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
			throw new NotImplementedException();
		}

		public override bool IsFolderExisted(string path)
		{
			throw new NotImplementedException();
		}

		public override void Move(string srcPath, string dstPath)
		{
			throw new NotImplementedException();
		}

		public override Stream OpenFile(string path, FileMode mode, FileAccess access)
		{
			throw new NotImplementedException();
		}

		public override void Reload(string path)
		{
			throw new NotImplementedException();
		}
	}
}

