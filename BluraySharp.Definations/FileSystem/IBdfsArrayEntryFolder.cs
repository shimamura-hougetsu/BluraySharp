using System.Collections.Generic;
using BluraySharp.Architecture;

namespace BluraySharp.FileSystem
{
	public interface IBdfsArrayEntryFolder<T> : IBdfsFolder<IBdfsArrayEntryFile<T>>
		where T : IBdArrayEntry
	{
		IBdList<IBdfsArrayEntryFile<T>> Files { get; }
	}
}
