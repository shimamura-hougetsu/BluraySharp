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
		public BdfsEntryFile(BdfsBase fs, string path, string backupPath)
		{
			this.path = path;
			this.backupPath = backupPath;
		}

		BdfsBase fs;
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

		public bool Save(T entry)
		{
			if (string.IsNullOrWhiteSpace(Path))
			{
				return false;
			}

			this.Save(entry, Path);
			return true;
		}

		public T Load()
		{
			if (!fs.IsFileExisted(Path))
			{
				return null;
			}

			return this.Load(Path);
		}

		public bool SaveBackup(T entry)
		{
			if (!this.compAttrib.IsBackupRequired)
			{
				return false;
			}
			
			if (string.IsNullOrWhiteSpace(BackupPath))
			{
				return false;
			}

			this.Save(entry, BackupPath);
			return true;
		}

		public T LoadBackup()
		{
			if (!this.compAttrib.IsBackupRequired)
			{
				return null;
			}
			
			if (string.IsNullOrWhiteSpace(BackupPath))
			{
				return null;
			}

			return this.Load(BackupPath);
		}

		private void Save(T entry, string path)
		{
			using (Stream tFile = fs.OpenFile(path, FileMode.Create, FileAccess.ReadWrite))
			{
				BdByteStreamWriteContext tRawIo = new BdByteStreamWriteContext(tFile);
				tRawIo.Serialize(entry);
			}
		}

		private T Load(string path)
		{
			using (Stream tFile = fs.OpenFile(path, FileMode.Open, FileAccess.Read))
			{
				T tRet = BdmvEntryRegistry.Instance.CreateEntry<T>();

				BdByteStreamReadContext tRawIo = new BdByteStreamReadContext(tFile);
				tRawIo.Deserialize(tRet);

				return tRet;
			}
		}
				
	}
}
