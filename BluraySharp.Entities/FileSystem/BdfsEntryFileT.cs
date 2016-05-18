/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at BitBucket (https://bitbucket.org/subelf/bluraysharp)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/

using BluraySharp.Architecture;
using BluraySharp.Common;
using System;
using System.IO;

namespace BluraySharp.FileSystem
{
	public class BdfsEntryFile<T> : BdfsItem, IBdfsEntryFile<T>
		where T : class, IBdmvEntry
	{
		public BdfsEntryFile(string path, string backupPath)
		{
			this.path = path;
			this.backupPath = backupPath;
		}

		protected BdmvEntryAttribute compAttrib = BdmvEntryRegistry.Instance.GetEntryAttribute<T>();

		private string path;

		public override string Path
		{
			get { return path; }
		}

		private string backupPath;

		public override string BackupPath
		{
			get { return backupPath; }
		}

		public bool Save(IBdfs fileSystem, T entry)
		{
			if (string.IsNullOrWhiteSpace(Path))
			{
				return false;
			}

			BdfsEntryFile<T>.Save(entry, fileSystem, Path);
			return true;
		}

		public T Load(IBdfs fileSystem)
		{
			if (! fileSystem.IsFileExist(Path))
			{
				return null;
			}

			return BdfsEntryFile<T>.Load(fileSystem, Path);
		}

		public bool SaveBackup(IBdfs fileSystem, T entry)
		{
			if (!this.compAttrib.IsBackupRequired)
			{
				return false;
			}
			
			if (string.IsNullOrWhiteSpace(BackupPath))
			{
				return false;
			}

			BdfsEntryFile<T>.Save(entry, fileSystem, BackupPath);
			return true;
		}

		public T LoadBackup(IBdfs fileSystem)
		{
			if (!this.compAttrib.IsBackupRequired)
			{
				return null;
			}
			
			if (string.IsNullOrWhiteSpace(BackupPath))
			{
				return null;
			}

			return BdfsEntryFile<T>.Load(fileSystem, BackupPath);
		}

		private static void Save(T entry, IBdfs fileSystem, string path)
		{
			using (Stream tFile = fileSystem.OpenFile(path, FileMode.Create, FileAccess.ReadWrite))
			{
				BdByteStreamWriteContext tRawIo = new BdByteStreamWriteContext(tFile);
				tRawIo.Serialize(entry);
			}
		}

		private static T Load(IBdfs fileSystem, string path)
		{
			using (Stream tFile = fileSystem.OpenFile(path, FileMode.Open, FileAccess.Read))
			{
				T tRet = BdmvEntryRegistry.Instance.CreateEntry<T>();

				BdByteStreamReadContext tRawIo = new BdByteStreamReadContext(tFile);
				tRawIo.Deserialize(tRet);

				return tRet;
			}
		}

		public override void Rename(IBdfs fileSystem, string newName)
		{
			//TODO:
			throw new NotImplementedException();
		}

		public override void MoveTo(IBdfs fileSystem, string newPath)
		{
			throw new NotImplementedException();
		}
	}
}
