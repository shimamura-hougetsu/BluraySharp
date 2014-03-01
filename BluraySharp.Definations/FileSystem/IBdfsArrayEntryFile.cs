using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common.Serializing;

namespace BluraySharp.FileSystem
{
	public interface IBdfsArrayEntryFile<T> : IBdfsComponentEntryFile<T>
		where T : IBdfsArrayEntry
	{
		uint FileId { get; set; }
	}
}
