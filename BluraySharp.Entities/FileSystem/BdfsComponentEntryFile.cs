using System;
using BluraySharp.Architecture;
using System.IO;
using LibElfin.WinApi.MemoryBlock;

namespace BluraySharp.FileSystem
{
	public class BdfsComponentEntryFile<T> : BdfsItem, IBdfsComponentEntryFile<T>
		where T : IBdComponentEntry
	{
		private BdComponentEntryAttribute compAttrib = BdEntitiesRegistry.Instance.GetEntryAttribute<T>();

		public void Save(T entry)
		{
			string tPath = this.GetFullPath();

			Save(entry, tPath);
		}

		public T Load()
		{
			string tPath = this.GetFullPath();

			return Load(tPath);
		}

		public void SaveBackup(T entry)
		{
			if (!this.compAttrib.IsBackupRequired)
			{
				throw new NotSupportedException();
			}

			string tPath = this.GetBackupPath();

			Save(entry, tPath);
		}

		public T LoadBackup()
		{
			if (!this.compAttrib.IsBackupRequired)
			{
				throw new NotSupportedException();
			}

			string tPath = this.GetBackupPath();

			return Load(tPath);
		}

		private static void Save(T entry, string tPath)
		{
			using (FileStream tFile = new FileStream(tPath, FileMode.Create, FileAccess.ReadWrite))
			{
				using (AutoFileMapMem tFileMem = new AutoFileMapMem(tFile, tFile.Length, System.IO.MemoryMappedFiles.MemoryMappedFileAccess.Read))
				{
					using (BdMemIoContext tRawIo = new BdMemIoContext(tFileMem))
					{
						tRawIo.Serialize(entry);
					}
				}
			}
		}

		private static T Load(string tPath)
		{
			using (FileStream tFile = new FileStream(tPath, FileMode.Open, FileAccess.Read))
			{
				using (AutoFileMapMem tFileMem = new AutoFileMapMem(tFile, tFile.Length, System.IO.MemoryMappedFiles.MemoryMappedFileAccess.Read))
				{
					using (BdMemIoContext tRawIo = new BdMemIoContext(tFileMem))
					{
						T tRet = BdEntitiesRegistry.Instance.CreateEntry<T>();
						tRawIo.Deserialize(tRet);

						return tRet;
					}
				}
			}
		}
	}
}
