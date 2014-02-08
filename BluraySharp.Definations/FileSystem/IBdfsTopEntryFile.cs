using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Architecture;

namespace BluraySharp.FileSystem
{
	public interface IBdfsTopEntryFile<T> : IBdfsItem
		where T : IBdTopEntry
	{
		void Save(T component);
		T Load();

		void SaveBackup(T component);
		T LoadBackup();
	}
}
