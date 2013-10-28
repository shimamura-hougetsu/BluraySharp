using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BluraySharp;
using LibElfin.WinApi.MemoryBlock;
using System.IO;
using BluraySharp.PlayList;

namespace BluraySharpTest
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			string tFilePath = @"C:\StoreBase\_Temp\玉响\!CMD.DIR\SUB\[BDMV][111221] たまゆら～hitotose～ 第1巻\TAMAYURA_HITOTOSE_1\BDMV\PLAYLIST\00002.mpls";
			FileInfo tFileInfo = new FileInfo(tFilePath);
			

			PlayList tMpls;

			using (FileStream tFileStream = new FileStream(tFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				using (AutoFileMapMem tFileMem = new AutoFileMapMem(tFileStream, tFileStream.Length, System.IO.MemoryMappedFiles.MemoryMappedFileAccess.Read))
				{
					BdRawSerializeContext tRawIo = new BdRawSerializeContext(tFileMem);
					tMpls = tRawIo.Deserialize<PlayList>();
				}
			}

			tMpls.ToString();
		}
	}
}
