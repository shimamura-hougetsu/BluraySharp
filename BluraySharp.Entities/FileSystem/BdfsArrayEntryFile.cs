using System;
using BluraySharp.Architecture;
using BluraySharp.Common;
using System.IO;
using LibElfin.WinApi.MemoryBlock;

namespace BluraySharp.FileSystem
{
	public class BdfsArrayEntryFile<T> : BdfsComponentEntryFile<T>, IBdfsArrayEntryFile<T>
		where T : IBdArrayEntry
	{
		private BdArrayEntryAttribute compAttrib =
			BdEntitiesRegistry.Instance.GetEntryAttribute<T>() as BdArrayEntryAttribute;

		private uint fileId;
		public uint FileId
		{
			get
			{
				return fileId;
			}
			set
			{
				if (value > this.compAttrib.MaxSerialNumber)
				{
					//TODO: invalid file id;
					throw new Exception();
				}

				this.Name = string.Format("{0:5}.{1}", value, this.compAttrib.Extension);
				fileId = value;
			}
		}

		public BdfsArrayEntryFile(IBdfsItem parent)
		{
			base.Parent = parent;
		}
	}
}
