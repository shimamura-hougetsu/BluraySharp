using BluraySharp.Common;
using System.Collections.Generic;
using System.IO;

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
