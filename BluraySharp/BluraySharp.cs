using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Playlist;
using System.IO;
using LibElfin.WinApi.MemoryBlock;

namespace BluraySharp
{
	public class BdmvTree
	{
		IPlayList OpenPlayList()
		{
			return new PlayList();
		}

		IPlayList OpenPlayList(FileStream file)
		{
			using (AutoFileMapMem tFileMem = new AutoFileMapMem(file, file.Length, System.IO.MemoryMappedFiles.MemoryMappedFileAccess.Read))
			{
				BdRawSerializeContext tRawIo = new BdRawSerializeContext(tFileMem);
				return tRawIo.Deserialize<PlayList>();
			}
		}
		
		public T Clone<T>(T obj) where T : IBdObject, new()
		{
			AutoHeapMem tMem = new AutoHeapMem(obj.RawLength);
			BdRawSerializeContext tRawIo = new BdRawSerializeContext(tMem);

			return tRawIo.Deserialize<T>();
		}
	}
}
