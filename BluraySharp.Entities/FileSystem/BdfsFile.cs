using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.FileSystem
{
	public abstract class BdfsFile : IBdfsItem
	{
		public string Name
		{
			get;
			protected set;
		}

		public IBdfsAttribute Attribute
		{
			get { throw new NotImplementedException(); }
		}

		public IBdfsItem Parent
		{
			get;
			private set;
		}

		public IEnumerable<IBdfsItem> Children
		{
			get { return null; }
		}
	}
}
