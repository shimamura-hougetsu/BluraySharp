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
			using (AutoFileMapMem tFileMem = new AutoFileMapMem(file, file.Length, System.IO.MemoryMappedFiles.MemoryMappedFileAccess.Read))
			{
				BdRawSerializeContext tRawIo = new BdRawSerializeContext(tFileMem);
				return tRawIo.Deserialize<PlayList>();
			}
		}
		
		public void Copy<T>(T src, T dest) where T : IBdObject
		{
			AutoHeapMem tMem = new AutoHeapMem(src.RawLength);
			BdRawSerializeContext tRawIo = new BdRawSerializeContext(tMem);

			tRawIo.Deserialize<T>(dest);
		}
	}
}
