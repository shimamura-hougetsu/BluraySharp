using BluraySharp.Architecture;
using BluraySharp.Common;
using System;
using System.IO;

namespace BluraySharp.FileSystem
{
	public class BdfsEntryFile<T> : BdfsItem, IBdfsEntryFile<T>
		where T : IBdmvEntry
	{
		protected BdmvEntryAttribute compAttrib = BdmvEntryRegistry.Instance.GetEntryAttribute<T>();

		public void Save(T entry)
		{
			string tPath = this.GetFullPath();

			BdfsEntryFile<T>.Save(entry, tPath);
		}

		public T Load()
		{
			string tPath = this.GetFullPath();

			return BdfsEntryFile<T>.Load(tPath);
		}

		public void SaveBackup(T entry)
		{
			if (!this.compAttrib.IsBackupRequired)
			{
				//TODO:
				throw new NotSupportedException();
			}

			string tPath = this.GetBackupPath();

			BdfsEntryFile<T>.Save(entry, tPath);
		}

		public T LoadBackup()
		{
			if (!this.compAttrib.IsBackupRequired)
			{
				//TODO:
				throw new NotSupportedException();
			}

			string tPath = this.GetBackupPath();

			return BdfsEntryFile<T>.Load(tPath);
		}

		private static void Save(T entry, string tPath)
		{
			using (FileStream tFile = new FileStream(tPath, FileMode.Create, FileAccess.ReadWrite))
			{
				BdByteStreamWriteContext tRawIo = new BdByteStreamWriteContext(tFile);
					tRawIo.Serialize(entry);
			}
		}

		private static T Load(string tPath)
		{
			using (FileStream tFile = new FileStream(tPath, FileMode.Open, FileAccess.Read))
			{
				T tRet = BdmvEntryRegistry.Instance.CreateEntry<T>();
				
				BdByteStreamReadContext tRawIo = new BdByteStreamReadContext(tFile);
				tRawIo.Deserialize(tRet);

				return tRet;
			}
		}
	}
}
