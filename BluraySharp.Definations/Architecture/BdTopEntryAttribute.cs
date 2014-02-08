using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Architecture
{
	public class BdTopEntryAttribute : Attribute
	{
		private bool isBackupRequired;
		public bool IsBackupRequired
		{
			get { return isBackupRequired; }
			set { isBackupRequired = value; }
		}

		private string filename;
		public string FileName
		{
			get { return filename; }
			set { filename = value; }
		}

		public BdTopEntryAttribute(string filename, bool isBackupRequired)
		{
			this.filename = filename;
			this.isBackupRequired = isBackupRequired;
		}
	}
}
