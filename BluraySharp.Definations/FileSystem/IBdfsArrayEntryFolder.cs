using System.Collections.Generic;
using BluraySharp.Architecture;

namespace BluraySharp.FileSystem
{
	public interface IBdfsArrayEntryFolder<T> : IBdfsFolder<IBdfsArrayEntryFile<T>>
		where T : IBdArrayEntry
	{
		IEnumerable<IBdfsArrayEntryFile<T>> Files { get; }

		IBdfsArrayEntryFile<T> CreateNewFile(uint fileId);
	}
}
