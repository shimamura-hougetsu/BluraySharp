
namespace BluraySharp.Architecture
{
	public interface IBdEntitiesRegistry
	{
		T CreateEntry<T>() where T : IBdComponentEntry;
		BdComponentEntryAttribute GetEntryAttribute<T>() where T : IBdComponentEntry;
	}
}
