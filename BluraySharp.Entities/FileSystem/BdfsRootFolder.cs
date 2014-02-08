using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.FileSystem
{
	public abstract class BdfsRootFolder : BdfsFolder<IBdfsItem>, IBdfsRootFolder
	{
		public abstract IEnumerable<Exception> Validate();
	}
}
