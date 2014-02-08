using System;
using BluraySharp.Architecture;
using BluraySharp.Common;

namespace BluraySharp.FileSystem
{
	public class BdfsComponentFile<T> : BdfsFile, IBdfsComponentFile<T>
		where T : IBdComponent
	{
		private uint fileId;
		public uint FileId
		{
			get
			{
				return fileId;
			}
			set
			{

				this.Name = string.Format("{0:5}.{1}", value, this.componentAttribute.Extension);
				fileId = value;
			}
		}

		public void Save(T component)
		{
			throw new NotImplementedException();
		}

		public T Load()
		{
			throw new NotImplementedException();
		}

		public void SaveBackup(T component)
		{
			throw new NotImplementedException();
		}

		public T LoadBackup()
		{
			throw new NotImplementedException();
		}

		private BdComponentAttribute componentAttribute;
		public BdfsComponentFile()
		{
			BdComponentAttribute[] tCompAttribs = typeof(T).GetCustomAttributes(typeof(BdComponentAttribute), true) as BdComponentAttribute[];
			if(tCompAttribs.Length > 1)
			{
				//Wont accept more than one BdComponentAttribute.
				throw new Exception();
			}
			else if(tCompAttribs.Length < 1)
			{
				//BdComponentAttribute needed for T.
				throw new Exception();
			}

			componentAttribute = tCompAttribs[0];
		}
	}
}
