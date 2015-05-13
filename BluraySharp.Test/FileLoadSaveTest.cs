using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BluraySharp;
using BluraySharp.PlayList;
using BluraySharp.ClipInfo;

namespace BluraySharp.Test
{
	[TestClass]
	public class FileLoadSaveTest
	{
		//Here is a simple usage:
		private static BdmvContext bdmv = new BdmvContext();

		[TestMethod]
		public void MplsLoadSave()
		{
			var fileName = @"D:\_Unsorted\[BDMV][アニメ][150424] 閃乱カグラ ESTIVAL VERSUS -水着だらけの前夜祭-\[ZMXZ-9967] SENRAN_KAGURA_ESTIVAL_VERSUS\BDMV\PLAYLIST\00001.mpls";
			//open the file
			var mplsFile = bdmv.OpenFile<IBdMpls>(fileName);
			//parse data of the file into a stuctured mpls object
			var mpls = mplsFile.Load();

			var output = @"T:\Drawer\00001.mpls";
			var tOutFile = bdmv.OpenFile<IBdMpls>(output);
			tOutFile.Save(mpls);

			var mpls2 = tOutFile.Load();
		}


		[TestMethod]
		public void ClpiLoadSave()
		{
			var fileName = @"D:\_Unsorted\[BDMV][アニメ][150424] 閃乱カグラ ESTIVAL VERSUS -水着だらけの前夜祭-\[ZMXZ-9967] SENRAN_KAGURA_ESTIVAL_VERSUS\BDMV\CLIPINF\00001.clpi";
			//open the file
			var clpiFile = bdmv.OpenFile<IBdClpi>(fileName);
			//parse data of the file into a stuctured mpls object
			var clpi = clpiFile.Load();

			var output = @"T:\Drawer\00001.clpi";
			var tOutFile = bdmv.OpenFile<IBdClpi>(output);
			tOutFile.Save(clpi);

			var clpi2 = tOutFile.Load();
		}
	}
}