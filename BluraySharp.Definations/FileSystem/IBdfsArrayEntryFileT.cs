using BluraySharp.Common;

namespace BluraySharp.FileSystem
{
	public interface IBdfsArrayEntryFile<T> : IBdfsEntryFile<T>
		where T : IBdmvArrayEntry
	{
		uint FileId { get; set; }
	}
}
