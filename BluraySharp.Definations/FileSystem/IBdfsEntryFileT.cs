
using BluraySharp.Common;

namespace BluraySharp.FileSystem
{
	public interface IBdfsEntryFile<T> : IBdfsItem
		where T : IBdmvEntry
	{
		void Save(T entry);
		T Load();

		void SaveBackup(T entry);
		T LoadBackup();
	}
}
