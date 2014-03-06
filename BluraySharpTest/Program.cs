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
			string tFilePath = @"C:\StoreBase\_Temp\[BDMV][120926] 超訳百人一首 うた恋い。1\[ANZX6141] UTAKOI_1\BDMV\PLAYLIST\00000.mpls";
			//string tFilePath = @"C:\Users\Subelf.J\Documents\stillinf-norand.mpls";
			using (FileStream tFileStream = new FileStream(tFilePath, FileMode.Open))
			{
				BdStreamReadContext tReader = new BdStreamReadContext(tFileStream);
				TestClass tMpls = new TestClass();
				tReader.Deserialize(tMpls);

				using (FileStream tBakStream = new FileStream(tFilePath + ".bak", FileMode.Open))
				{
					tMpls.ExtDataSeg = new BdExtensionData();
					tMpls.ExtDataLen = 10;
					BdStreamWriteContext tWriter = new BdStreamWriteContext(tBakStream);
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
