using BluraySharp.Common;

namespace BluraySharp.FileSystem
{
	public interface IBdfsArrayComponentFile<T> : IBdfsComponentFile<T>
		where T : IBdArrayComponent
	{
		uint FileId { get; set; }
	}
}
