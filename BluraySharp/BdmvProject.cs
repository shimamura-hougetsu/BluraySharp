using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Playlist;
using System.IO;
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
				BdRawSerializeContext tRawIo = new BdRawSerializeContext(tFileMem);
				return tRawIo.Deserialize<PlayList>();
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
				BdRawSerializeContext tRawIo = new BdRawSerializeContext(tFileMem);
				tRawIo.Serialize(playList);
			}
		}
		
		public void Copy<T>(T src, T dest) where T : IBdObject
		{
			if (object.ReferenceEquals(dest, null))
			{
				throw new ArgumentNullException("playList");
			}

			if (!object.ReferenceEquals(src, null))
			{
				AutoHeapMem tMem = new AutoHeapMem(src.RawLength);
				BdRawSerializeContext tRawIo = new BdRawSerializeContext(tMem);

				tRawIo.Deserialize<T>(dest);
			}
		}
	}
}
