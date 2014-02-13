using System;
using System.IO;
using BluraySharp;
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
			//string tFilePath = @"C:\StoreBase\_Temp\玉响\[BDMV][111221] たまゆら～hitotose～ 第1巻\TAMAYURA_HITOTOSE_1\BDMV\PLAYLIST\00000.mpls";
			string tFilePath = @"C:\Users\Subelf.J\Documents\stillinf-norand.mpls";

			using (FileStream tFileStream = new FileStream(tFilePath, FileMode.Open))
			{
				BdmvContext tContext = new BdmvContext();
				IPlayList tMpls = tContext.OpenComponentFile<IPlayList>(tFileStream);

				System.Diagnostics.Debug.WriteLine(
				        tMpls.PlayItemList.PlayItems[0].ConnectionCondition.ToStringLocalized()
				    );

				tMpls.ToString();
			}
		}
	}
}
