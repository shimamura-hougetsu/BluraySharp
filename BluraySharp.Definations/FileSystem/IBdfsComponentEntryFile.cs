
using BluraySharp.Architecture;

namespace BluraySharp.FileSystem
{
	public interface IBdfsComponentEntryFile<T> : IBdfsItem
		where T : IBdComponentEntry
	{
		void Save(T entry);
		T Load();

		void SaveBackup(T entry);
		T LoadBackup();
	}
}
