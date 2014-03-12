using System;
using System.IO;
using BluraySharp.Architecture;
using BluraySharp.PlayList;
using BluraySharp.Common.Serializing;
using BluraySharp.Common;
using BluraySharp.FileSystem;

namespace BluraySharp
{
	public class BdmvContext
	{
		private static BdmvEntryRegistry entryRegistry = BdmvEntryRegistry.Instance;
		public T CreateNewBdmvEntry<T>() where T : IBdmvEntry
		{
			return entryRegistry.CreateEntry<T>();
		}

		public IBdfsEntryFile<T> OpenFile<T>(string filePath) where T : IBdmvEntry
		{
			return new BdfsStandaloneFile<T>(filePath);
		}

		public IBdfsRootFolder OpenBdmvFolder(string directoryPath)
		{
			throw new NotImplementedException();
		}

		public void Copy<T>(T src, T dest) where T : IBdPart
		{
			if (object.ReferenceEquals(dest, null))
			{
				throw new ArgumentNullException("dest");
			}

			if (!object.ReferenceEquals(src, null))
			{
				using (MemoryStream tMem = new MemoryStream())
				{
					IBdRawWriteContext tSerializer = new BdByteStreamWriteContext(tMem);
					tSerializer.Serialize(src);

					tMem.Position = 0;

					IBdRawReadContext tDeserializer = new BdByteStreamReadContext(tMem);
					tDeserializer.Deserialize(dest);
				}
			}
		}
	}
}
