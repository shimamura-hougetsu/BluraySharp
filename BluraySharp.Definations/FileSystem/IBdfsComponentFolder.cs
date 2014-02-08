using System.Collections.Generic;
using BluraySharp.Architecture;

namespace BluraySharp.FileSystem
{
	public interface IBdfsComponentFolder<T> : IBdfsFolder<IBdfsComponentFile<T>>
		where T : IBdComponent
	{
		IEnumerable<IBdfsComponentFile<T>> Files { get; }

		IBdfsComponentFile<T> CreateNewFile(uint fileId);
	}
}
