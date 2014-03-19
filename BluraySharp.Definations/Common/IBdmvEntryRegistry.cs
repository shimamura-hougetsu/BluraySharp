
using BluraySharp.Common;

namespace BluraySharp.Common
{
	public interface IBdmvEntryRegistry
	{
		T CreateEntry<T>() where T : class, IBdmvEntry;
		BdmvEntryAttribute GetEntryAttribute<T>() where T : class, IBdmvEntry;
	}
}
