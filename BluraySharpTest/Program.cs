using System;
using System.IO;
using BluraySharp;
using BluraySharp.Playlist;
using LibElfin.WinApi.MemoryBlock;

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
			//string tFilePath = @"C:\StoreBase\_Temp\玉响\[BDMV][111221] たまゆら～hitotose～ 第1巻\TAMAYURA_HITOTOSE_1\BDMV\PLAYLIST\00000.mpls";
			string tFilePath = @"T:\Archives\_BDRip\鬼父.ZHO\ONICHICHI\BDMV\PLAYLIST\00000.mpls";
			FileInfo tFileInfo = new FileInfo(tFilePath);

			IPlayList tMpls = null;

			using (FileStream tFileStream = new FileStream(tFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				using (AutoFileMapMem tFileMem = new AutoFileMapMem(tFileStream, tFileStream.Length, System.IO.MemoryMappedFiles.MemoryMappedFileAccess.Read))
				{
					BdRawSerializeContext tRawIo = new BdRawSerializeContext(tFileMem);
					//tMpls = tRawIo.Deserialize<PlayList>();
				}
			}

			tMpls.ToString();
			tMpls.PlayItemList.PlayItems[0].ConnectionCondition.ToStringLocalized();
		}
	}
}
