using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.FileSystem
{
	public interface IBdfsItem
	{
		string Name { get; }
		IBdfsAttribute Attribute { get; }

		IBdfsItem Parent { get; }
		IEnumerable<IBdfsItem> Children { get; }

		IBdfsItem FindObjectByPath(string pathString, string splitter=@"\");
		string GetFullPath();

		string ToString();
	}
}
