using System;
using BluraySharp.Architecture;
using BluraySharp.Common;
using System.IO;

namespace BluraySharp.FileSystem
{
	public class BdfsArrayEntryFile<T> : BdfsComponentEntryFile<T>, IBdfsArrayEntryFile<T>
		where T : IBdArrayEntry
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
				BdArrayEntryAttribute tCompAttrib = compAttrib as BdArrayEntryAttribute;

				if (value > tCompAttrib.MaxSerialNumber)
				{
					//TODO: invalid file id;
					throw new Exception();
				}

				this.Name = string.Format("{0:5}.{1}", value, tCompAttrib.Extension);
				fileId = value;
			}
		}

		public BdfsArrayEntryFile(IBdfsItem parent)
		{
			base.Parent = parent;
		}
	}
}
