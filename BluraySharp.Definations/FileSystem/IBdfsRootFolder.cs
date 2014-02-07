using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.FileSystem
{
	public interface IBdfsRootFolder : IBdfsFolder<IBdfsItem>
	{
		IEnumerable<Exception> Validate();
	}
}
