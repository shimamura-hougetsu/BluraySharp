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
			string tFilePath = @"C:\StoreBase\_Temp\[BDMV][120926] 超訳百人一首 うた恋い。1\[ANZX6141] UTAKOI_1\BDMV\PLAYLIST\00100.mpls";
			//string tFilePath = @"C:\Users\Subelf.J\Documents\stillinf-norand.mpls";
			using (FileStream tFileStream = new FileStream(tFilePath, FileMode.Open))
			{
				BdByteStreamReadContext tReader = new BdByteStreamReadContext(tFileStream);
				IPlayList tMpls = new BdMoviePlayList();
				tReader.Deserialize(tMpls);

				using (FileStream tBakStream = new FileStream(tFilePath + ".bak", FileMode.Create))
				{
					IBdList<IPlStnStEntry> tStList = tMpls.PlayItemList.PlayItems[0].StnTable.StStreams;
					IPlStnStEntry tSubtitle = tStList.CreateNew();
					tSubtitle.EntryType = PlStnStreamEntryType.SubPlayItem;
					{
						IPlStnSubPlayItemEntryInfo tSubtitleEntry = tSubtitle.EntryInfo as IPlStnSubPlayItemEntryInfo;
						tSubtitleEntry.SubPathId = 0;
						tSubtitleEntry.SubClipEntryId = 0;
						tSubtitleEntry.StreamProgId = 4608;
					}
					tSubtitle.CodecInfoType = BdStCodingType.GxPresentation;
					{
						IPlStnGxCodecInfo tSubtitleCodec = tSubtitle.CodecInfo as IPlStnGxCodecInfo;
						tSubtitleCodec.Language = BdLang.LANG_ZHO;
					}
					tStList.Add(tSubtitle);

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
