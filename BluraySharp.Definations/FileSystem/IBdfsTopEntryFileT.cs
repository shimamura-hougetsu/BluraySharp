using BluraySharp.Common;

namespace BluraySharp.FileSystem
{
	public interface IBdfsTopEntryFile<T> : IBdfsEntryFile<T>
		where T : IBdmvTopEntry
	{
	}
}
