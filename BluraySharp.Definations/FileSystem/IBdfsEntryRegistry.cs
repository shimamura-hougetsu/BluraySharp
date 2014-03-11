
using BluraySharp.Common;

namespace BluraySharp.FileSystem
{
	public interface IBdfsEntryRegistry
	{
		T CreateEntry<T>() where T : IBdmvEntry;
		BdmvEntryAttribute GetEntryAttribute<T>() where T : IBdmvEntry;
	}
}
