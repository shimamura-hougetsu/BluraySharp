
namespace BluraySharp.FileSystem
{
	public interface IBdfsFolder<T> : IBdfsItem
		where T : IBdfsItem
	{
		void Detach(T fsObject);
		void Attach(T fsObject);
	}
}
