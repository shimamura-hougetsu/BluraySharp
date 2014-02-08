using System;
using System.IO;
using BluraySharp.Architecture;
using BluraySharp.Playlist;
using LibElfin.WinApi.MemoryBlock;

namespace BluraySharp
{
	public class BdmvProject
	{
		public IPlayList CreatePlayList()
		{
			return new PlayList();
		}

		public IPlayList OpenPlayList(FileStream file)
		{
			if (object.ReferenceEquals(file, null))
			{
				throw new ArgumentNullException("file");
			}

			using (AutoFileMapMem tFileMem = new AutoFileMapMem(file, file.Length, System.IO.MemoryMappedFiles.MemoryMappedFileAccess.Read))
			{
				using (BdMemIoContext tRawIo = new BdMemIoContext(tFileMem))
				{
					return tRawIo.Deserialize<PlayList>();
				}
			}
		}

		public void SavePlayList(FileStream file, IPlayList playList)
		{
			if (object.ReferenceEquals(file, null))
			{
				throw new ArgumentNullException("file");
			}

			if (object.ReferenceEquals(playList, null))
			{
				throw new ArgumentNullException("playList");
			}

			using (AutoFileMapMem tFileMem = new AutoFileMapMem(file, playList.RawLength, System.IO.MemoryMappedFiles.MemoryMappedFileAccess.ReadWrite))
			{
				using (BdMemIoContext tRawIo = new BdMemIoContext(tFileMem))
				{
					tRawIo.Serialize(playList);
				}
			}
		}
		
		public void Copy<T>(T src, T dest) where T : IBdPart
		{
			if (object.ReferenceEquals(dest, null))
			{
				throw new ArgumentNullException("playList");
			}

			if (!object.ReferenceEquals(src, null))
			{
				using (AutoHeapMem tMem = new AutoHeapMem(src.RawLength))
				{
					using (BdMemIoContext tSerializer = new BdMemIoContext(tMem))
					{
						tSerializer.Serialize<T>(src);
					}

					using (BdMemIoContext tDeserializer = new BdMemIoContext(tMem))
					{
						tDeserializer.Deserialize<T>(dest);
					}
				}
			}
		}
	}
}
