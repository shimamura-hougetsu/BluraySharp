
namespace BluraySharp.FileSystem
{
	public interface IBdfsEntitiesRegistry
	{
		T CreateEntry<T>() where T : IBdfsComponentEntry;
		BdfsComponentEntryAttribute GetEntryAttribute<T>() where T : IBdfsComponentEntry;
	}
}
