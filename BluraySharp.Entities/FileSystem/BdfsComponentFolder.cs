using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Architecture;

namespace BluraySharp.FileSystem
{
	public class BdfsComponentFolder<T> : BdfsFolder<IBdfsComponentFile<T>>, IBdfsComponentFolder<T>
		where T: IBdComponent
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

		public IEnumerable<IBdfsComponentFile<T>> Files
		{
			get
			{
				return base.children;
			}
		}

		public IBdfsComponentFile<T> CreateNewFile(uint fileId)
		{
			BdfsComponentFile<T> tRet = new BdfsComponentFile<T>();
			tRet.FileId = fileId;
			this.Attach(tRet);

			return tRet;
		}

		private BdEntitiesRegistry registry = BdEntitiesRegistry.Instance;
		public BdfsComponentFolder()
		{
			base.Name = registry.GetComponentAttribute<T>().FolderName;
		}
	}
}
