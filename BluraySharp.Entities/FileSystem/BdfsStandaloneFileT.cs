using BluraySharp.Common;

namespace BluraySharp.FileSystem
{
	public class BdfsStandaloneFile<T> : BdfsEntryFile<T>, IBdfsEntryFile<T>
		where T : class, IBdmvEntry
	{
		public BdfsStandaloneFile(string path)
		{
			base.Name = path;
		}

		public override string GetBackupPath()
		{
			return null;
		}

		public override string GetFullPath()
		{
			return this.Name;
		}
	}
}
