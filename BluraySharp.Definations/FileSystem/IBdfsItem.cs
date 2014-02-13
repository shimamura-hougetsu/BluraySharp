using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BluraySharp.Architecture;

namespace BluraySharp.FileSystem
{
	public interface IBdfsItem : IEnumerable<IBdfsItem>
	{
		string Name { get; set; }

		FileSystemInfo DetailedInfo { get; }
		IBdfsAttribute Attribute { get; }

		IBdfsItem Parent { get; }
		IBdList<IBdfsItem> Children { get; }
		
		string GetFullPath();
		string GetBackupPath();
	}
}
