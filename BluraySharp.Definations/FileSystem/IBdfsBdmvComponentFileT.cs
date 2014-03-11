using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common.Serializing;
using BluraySharp.Common;

namespace BluraySharp.FileSystem
{
	public interface IBdfsTopEntryFile<T> : IBdfsComponentFile<T>
		where T : IBdBdmvComponent
	{
	}
}
