using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Architecture;

namespace BluraySharp.FileSystem
{
	public interface IBdfsTopEntryFile<T> : IBdfsComponentEntryFile<T>
		where T : IBdTopEntry
	{
	}
}
