using System.Collections.Generic;
using BluraySharp.Common;

namespace BluraySharp.FileSystem
{
	public interface IBdfsArrayComponentFolder<T> : IBdfsFolder<IBdfsArrayComponentFile<T>>
		where T : IBdArrayComponent
	{
		IBdList<IBdfsArrayComponentFile<T>> Files { get; }
	}
}
