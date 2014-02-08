using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Architecture
{
	public class BdComponentAttribute : Attribute
	{
		private bool isBackupRequired;

		public bool IsBackupRequired
		{
			get { return isBackupRequired; }
			set { isBackupRequired = value; }
		}

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

		private string extension;

		public string Extension
		{
			get { return extension; }
			set { extension = value; }
		}

		public BdComponentAttribute(string folderName, string extension, int maxSerialNumber, bool isBackupRequired)
		{
			this.folderName = folderName;
			this.extension = extension;
			this.maxSerialNumber = maxSerialNumber;
			this.isBackupRequired = isBackupRequired;
		}
	}
}
