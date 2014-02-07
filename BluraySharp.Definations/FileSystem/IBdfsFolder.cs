using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.FileSystem
{
	public interface IBdfsFolder<T> : IBdfsItem, IEnumerable<T>
		where T : IBdfsItem
	{
		void Detach(T fsObject);
		void Attach(T fsObject);
	}
}
