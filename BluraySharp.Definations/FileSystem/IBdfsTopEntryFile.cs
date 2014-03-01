using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common.Serializing;

namespace BluraySharp.FileSystem
{
	public interface IBdfsTopEntryFile<T> : IBdfsComponentEntryFile<T>
		where T : IBdfsTopEntry
	{
	}
}
