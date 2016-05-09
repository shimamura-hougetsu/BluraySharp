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
		protected BdmvEntryAttribute compAttrib = BdmvEntryRegistry.Instance.GetEntryAttribute<T>();

		public bool Save(T entry)
		{
			string tPath = this.GetFullPath();
			if (string.IsNullOrWhiteSpace(tPath))
			{
				return false;
			}

			BdfsEntryFile<T>.Save(entry, tPath);
			return true;
		}

		public T Load()
		{
			string tPath = this.GetFullPath();
			if (string.IsNullOrWhiteSpace(tPath))
			{
				return null;
			}

			return BdfsEntryFile<T>.Load(tPath);
		}

		public bool SaveBackup(T entry)
		{
			if (!this.compAttrib.IsBackupRequired)
			{
				return false;
			}

			string tPath = this.GetBackupPath();
			if (string.IsNullOrWhiteSpace(tPath))
			{
				return false;
			}

			BdfsEntryFile<T>.Save(entry, tPath);
			return true;
		}

		public T LoadBackup()
		{
			if (!this.compAttrib.IsBackupRequired)
			{
				return null;
			}

			string tPath = this.GetBackupPath();
			if (string.IsNullOrWhiteSpace(tPath))
			{
				return null;
			}

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
