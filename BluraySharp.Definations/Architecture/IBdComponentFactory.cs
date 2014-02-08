
namespace BluraySharp.Architecture
{
	public interface IBdEntitiesRegistry
	{
		T CreateComponent<T>() where T : IBdComponent;
		T CreateTopEntry<T>() where T : IBdTopEntry;

		BdComponentAttribute GetComponentAttribute<T>() where T : IBdComponent;
		BdTopEntryAttribute GetTopEntryAttribute<T>() where T : IBdTopEntry;
	}
}
