using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BluraySharp.FileSystem
{
	public abstract class BdfsBase : IBdfs
	{
		public abstract IBdfsBdmvRoot BdmvFolder { get; }

		public abstract void Reload(string path);
		public abstract Stream OpenFile(string path, FileMode mode, FileAccess access);
		
		public abstract bool IsFileExisted(string path);
		public abstract bool IsFolderExisted(string path);

		public abstract void CreateFolder(string path);
		public abstract void Move(string srcPath, string dstPath);
	}
}
