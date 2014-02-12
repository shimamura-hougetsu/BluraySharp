using System;
using System.IO;
using BluraySharp.Architecture;
using BluraySharp.Playlist;

namespace BluraySharp
{
	public class BdmvContext
	{
		private IBdEntitiesRegistry registry = BdEntitiesRegistry.Instance;

		public IPlayList CreatePlayList()
		{
			return new PlayList();
		}

		public T OpenComponent<T>(FileStream file) where T: IBdComponentEntry
		{
			if (object.ReferenceEquals(file, null))
			{
				throw new ArgumentNullException("file");
			}

			IBdRawReadContext tRawIo = new BdStreamReadContext(file);
			T tRet = this.registry.CreateEntry<T>();
			tRawIo.Deserialize<T>(tRet);

			return tRet;
		}

		public void SaveComponent<T>(FileStream file, T component) where T: IBdComponentEntry
		{
			if (object.ReferenceEquals(file, null))
			{
				throw new ArgumentNullException("file");
			}

			if (object.ReferenceEquals(component, null))
			{
				throw new ArgumentNullException("playList");
			}

			IBdRawWriteContext tRawIo = new BdStreamWriteContext(file);
			tRawIo.Serialize<T>(component);
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
					IBdRawWriteContext tSerializer = new BdStreamWriteContext(tMem);
					tSerializer.Serialize<T>(src);

					tMem.Position = 0;

					IBdRawReadContext tDeserializer = new BdStreamReadContext(tMem);
					tDeserializer.Deserialize<T>(dest);
				}
			}
		}
	}
}
