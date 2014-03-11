using BluraySharp.Common;

namespace BluraySharp.FileSystem
{
	public interface IBdfsArrayEntryFile<T> : IBdfsComponentEntryFile<T>
		where T : IBdArrayComponent
	{
		uint FileId { get; set; }
	}
}
