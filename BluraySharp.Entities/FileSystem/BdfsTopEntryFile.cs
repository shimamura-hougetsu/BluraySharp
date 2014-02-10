using System;
using BluraySharp.Architecture;

namespace BluraySharp.FileSystem
{
	public class BdfsTopEntryFile<T> : BdfsComponentEntryFile<T>, IBdfsTopEntryFile<T>
		where T : IBdTopEntry
	{
		public override string Name
		{
			get
			{
				return base.Name;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public BdfsTopEntryFile(IBdfsItem parent)
		{
			BdTopEntryAttribute tEntryAttrib = compAttrib as BdTopEntryAttribute;

			base.Name = string.Format("{0}.{1}", tEntryAttrib.FileName, tEntryAttrib.Extension);

			base.Parent = parent;
		}
	}
}
