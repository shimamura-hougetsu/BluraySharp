using System;
using BluraySharp.Architecture;
using System.IO;

namespace BluraySharp.FileSystem
{
	public class BdfsComponentEntryFile<T> : BdfsItem, IBdfsComponentEntryFile<T>
		where T : IBdComponentEntry
	{
		protected BdComponentEntryAttribute compAttrib = BdEntitiesRegistry.Instance.GetEntryAttribute<T>();

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
				BdStreamWriteContext tRawIo = new BdStreamWriteContext(tFile);
					tRawIo.Serialize(entry);
			}
		}

		private static T Load(string tPath)
		{
			using (FileStream tFile = new FileStream(tPath, FileMode.Open, FileAccess.Read))
			{
				T tRet = BdEntitiesRegistry.Instance.CreateEntry<T>();

				BdStreamReadContext tRawIo = new BdStreamReadContext(tFile);
				tRawIo.Deserialize(tRet);

				return tRet;
			}
		}
	}
}
