
using BluraySharp.Common.Serializing;

namespace BluraySharp.FileSystem
{
	public interface IBdfsComponentEntryFile<T> : IBdfsItem
		where T : IBdfsComponentEntry
	{
		void Save(T entry);
		T Load();

		void SaveBackup(T entry);
		T LoadBackup();
	}
}
