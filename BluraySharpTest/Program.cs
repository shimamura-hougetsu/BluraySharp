using System;
using System.IO;
using BluraySharp;
using BluraySharp.PlayList;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Diagnostics;
using BluraySharp.Common.BdStandardPart;
using BluraySharp.Architecture;
using BluraySharp.Common;

namespace BluraySharpTest
{
	static class Program
	{
		enum A
		{
			NA
		}
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			string tInFilePath = @"C:\StoreBase\_Temp\[BDMV][Bakuman. S1-S3].ZHO\!CMD.DIR\SUB\[BDMV][アニメ][120620] バクマン。2ndシリーズ BD-BOX1\BAKUMAN_10\BDMV\PLAYLIST\00000.mpls";
			string tOutFilePath = @"C:\StoreBase\_Temp\[BDMV][Bakuman. S1-S3].ZHO\!CMD.DIR\SUB\[BDMV][アニメ][120620] バクマン。2ndシリーズ BD-BOX1\BAKUMAN_10\BDMV\PLAYLIST\00999.mpls";
			using (FileStream tFileStream = new FileStream(tInFilePath, FileMode.Open))
			{
				BdByteStreamReadContext tReader = new BdByteStreamReadContext(tFileStream);
				IPlayList tMpls = new BdMoviePlayList();
				tReader.Deserialize(tMpls);

				using (FileStream tBakStream = new FileStream(tOutFilePath, FileMode.Create))
				{
					IBdList<IPlSubPlayItem> tList = tMpls.PlayItemList.SubPaths[0].PlayItems;
					IPlSubPlayItem tItem = tList.CreateNew();
					tItem.ClipList[0].ClipFileRef.ClipId = 33;
					tItem.InTime.AsSpan = new TimeSpan(0, 0, 10, 00, 00);
					tItem.OutTime.AsSpan = new TimeSpan(0, 1, 59, 31, 00);
					tItem.ConnectionCondition = BdConnectionCondition.NotSeamless;
					tItem.SyncPlayItemId = 0;
					tItem.SyncPlayTime = new BdTime();
					tList.Add(tItem);

					BdByteStreamWriteContext tWriter = new BdByteStreamWriteContext(tBakStream);
					tWriter.Serialize(tMpls);
				}
				tMpls.ToString();
			}


			//using (FileStream tFileStream = new FileStream(tFilePath, FileMode.Open))
			//{
			//    BdmvContext tContext = new BdmvContext();
			//    IPlayList tMpls = tContext.OpenComponentFile<IPlayList>(tFileStream);

			//    System.Diagnostics.Debug.WriteLine(
			//            tMpls.PlayItemList.PlayItems[0].ConnectionCondition.ToStringLocalized()
			//        );

			//    tMpls.ToString();
			//}
		}
	}
}
