using System;
using BluraySharp.Architecture;
using BluraySharp.Common;
using System.IO;
using LibElfin.WinApi.MemoryBlock;

namespace BluraySharp.FileSystem
{
	public class BdfsComponentFile<T> : BdfsItem, IBdfsComponentFile<T>
		where T : IBdComponent
	{
		private BdComponentAttribute compAttrib = BdEntitiesRegistry.Instance.GetComponentAttribute<T>();

		private uint fileId;
		public uint FileId
		{
			get
			{
				return fileId;
			}
			set
			{
				if (value > this.compAttrib.MaxSerialNumber)
				{
					//TODO: invalid file id;
					throw new Exception();
				}

				this.Name = string.Format("{0:5}.{1}", value, this.compAttrib.Extension);
				fileId = value;
			}
		}

		public void Save(T component)
		{
			string tPath = this.GetFullPath();

			Save(component, tPath);
		}

		public T Load()
		{
			string tPath = this.GetFullPath();

			return Load(tPath);
		}

		public void SaveBackup(T component)
		{
			if (!this.compAttrib.IsBackupRequired)
			{
				throw new NotSupportedException();
			}

			string tPath = this.GetBackupPath();

			Save(component, tPath);
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

		private static void Save(T component, string tPath)
		{
			using (FileStream tFile = new FileStream(tPath, FileMode.Create, FileAccess.ReadWrite))
			{
				using (AutoFileMapMem tFileMem = new AutoFileMapMem(tFile, tFile.Length, System.IO.MemoryMappedFiles.MemoryMappedFileAccess.Read))
				{
					using (BdMemIoContext tRawIo = new BdMemIoContext(tFileMem))
					{
						tRawIo.Serialize(component);
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
						T tRet = BdEntitiesRegistry.Instance.CreateComponent<T>();
						tRawIo.Deserialize(tRet);

						return tRet;
					}
				}
			}
		}
	}
}
