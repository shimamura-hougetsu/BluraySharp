using System.Collections.Generic;
using BluraySharp.Common;

namespace BluraySharp.FileSystem
{
	public interface IBdfsArrayEntryFolder<T> : IBdfsFolder<IBdfsArrayEntryFile<T>>
		where T : IBdmvArrayEntry
	{
		IBdList<IBdfsArrayEntryFile<T>> Files { get; }
	}
}
