using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Architecture;

namespace BluraySharp.FileSystem
{
	public class BdfsArrayEntryFolder<T> : BdfsFolder<IBdfsArrayEntryFile<T>>, IBdfsArrayEntryFolder<T>
		where T: IBdArrayEntry
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

		public IEnumerable<IBdfsArrayEntryFile<T>> Files
		{
			get
			{
				return base.children;
			}
		}

		public IBdfsArrayEntryFile<T> CreateNewFile(uint fileId)
		{
			BdfsArrayEntryFile<T> tRet = new BdfsArrayEntryFile<T>(this);
			tRet.FileId = fileId;
			this.Attach(tRet);

			return tRet;
		}

		public BdfsArrayEntryFolder(IBdfsItem parent)
		{
			this.Parent = parent;

			BdArrayEntryAttribute tEntryAttrib =
				BdEntitiesRegistry.Instance.GetEntryAttribute<T>() as BdArrayEntryAttribute;

			base.Name = tEntryAttrib.FolderName;
		}
	}
}
