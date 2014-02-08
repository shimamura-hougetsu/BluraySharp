using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Architecture;

namespace BluraySharp.FileSystem
{
	public interface IBdfsComponentFile<T> : IBdfsItem
		where T : IBdComponent
	{
		uint FileId { get; set; }

		void Save(T component);
		T Load();

		void SaveBackup(T component);
		T LoadBackup();
	}
}
