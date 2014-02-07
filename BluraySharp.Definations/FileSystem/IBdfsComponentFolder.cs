using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.FileSystem
{
	public interface IBdfsComponentFolder<T> : IBdfsFolder<IBdfsComponentFile<T>>
		where T : IBdComponent
	{
	}
}
