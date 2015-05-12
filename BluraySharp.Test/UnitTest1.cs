using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BluraySharp;
using BluraySharp.PlayList;
using BluraySharp.ClipInfo;

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
			var fileName = @"00001.clpi";
			//open the file
			var clpiFile = bdmv.OpenFile<IBdClpi>(fileName);
			//parse data of the file into a stuctured mpls object
			var clpi = clpiFile.Load();

		}
	}
}