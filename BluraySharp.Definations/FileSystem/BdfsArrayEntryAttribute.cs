using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.FileSystem
{
	public class BdArrayEntryAttribute : BdfsComponentEntryAttribute
	{
		private string folderName;

		public string FolderName
		{
			get { return folderName; }
			set { folderName = value; }
		}
		
		private int maxSerialNumber;

		public int MaxSerialNumber
		{
			get { return maxSerialNumber; }
			set { maxSerialNumber = value; }
		}

		public BdArrayEntryAttribute(string folderName, string extension, int maxSerialNumber, bool isBackupRequired)
			: base(extension, isBackupRequired)
		{
			this.folderName = folderName;
			this.maxSerialNumber = maxSerialNumber;
		}
	}
}
