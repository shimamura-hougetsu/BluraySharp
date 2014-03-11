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
using BluraySharp.FileSystem;

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
			BdmvContext tBdmvContext = new BdmvContext();

			string tInFilePath = @"C:\StoreBase\_Temp\[BDMV][Bakuman. S1-S3].ZHO\!CMD.DIR\SUB\[BDMV][アニメ][120620] バクマン。2ndシリーズ BD-BOX1\BAKUMAN_10\BDMV\PLAYLIST\00000.mpls";
			string tOutFilePath = @"C:\StoreBase\_Temp\[BDMV][Bakuman. S1-S3].ZHO\!CMD.DIR\SUB\[BDMV][アニメ][120620] バクマン。2ndシリーズ BD-BOX1\BAKUMAN_10\BDMV\PLAYLIST\00999.mpls";

			IBdfsEntryFile<IBdMpls> tInFile = tBdmvContext.OpenFile<IBdMpls>(tInFilePath);
			IBdfsEntryFile<IBdMpls> tOutFile = tBdmvContext.OpenFile<IBdMpls>(tOutFilePath);

			IBdMpls tMpls = tInFile.Load();
			tOutFile.Save(tMpls);
		}
	}
}
