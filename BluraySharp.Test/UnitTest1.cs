using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BluraySharp;
using BluraySharp.PlayList;

namespace BluraySharp.Test
{
	[TestClass]
	public class UnitTest1
	{
		//Here is a simple usage:
		private static BdmvContext bdmv = new BdmvContext();

		[TestMethod]
		public void Load()
		{
			var fileName = @"00011.mpls";
			//open the file
			var mplsFile = bdmv.OpenFile<IBdMpls>(fileName);
			//parse data of the file into a stuctured mpls object
			var mpls = mplsFile.Load();

		}
	}
}