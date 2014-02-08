using BluraySharp.Architecture;

namespace BluraySharp.FileSystem
{
	public class BdfsTopEntryFile<T> : BdfsComponentEntryFile<T>, IBdfsTopEntryFile<T>
		where T : IBdTopEntry
	{
		public BdfsTopEntryFile(IBdfsItem parent)
		{
			base.Parent = parent;
		}
	}
}
