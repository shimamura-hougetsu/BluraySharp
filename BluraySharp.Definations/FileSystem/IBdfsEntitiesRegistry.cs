
using BluraySharp.Common;

namespace BluraySharp.FileSystem
{
	public interface IBdfsEntitiesRegistry
	{
		T CreateEntry<T>() where T : IBdComponent;
		BdComponentAttribute GetEntryAttribute<T>() where T : IBdComponent;
	}
}
