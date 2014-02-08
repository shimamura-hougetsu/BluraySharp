using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Architecture
{
	public class BdTopEntryAttribute : Attribute
	{
		private bool requireBackup;

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

		public bool RequireBackup
		{
			get { return requireBackup; }
			set { requireBackup = value; }
		}

		public BdTopEntryAttribute(string folderName, string extension, int maxSerialNumber, bool requireBackup)
		{
			this.folderName = folderName;
			this.extension = extension;
			this.maxSerialNumber = maxSerialNumber;
			this.requireBackup = requireBackup;
		}
	}
}
