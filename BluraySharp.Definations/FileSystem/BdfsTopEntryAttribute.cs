using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.FileSystem
{
	public class BdfsTopEntryAttribute : BdfsComponentEntryAttribute
	{
		private string filename;
		public string FileName
		{
			get { return filename; }
			set { filename = value; }
		}

		public BdfsTopEntryAttribute(string filename, bool isBackupRequired)
			: base("bdmv", isBackupRequired)
		{
			this.filename = filename;
		}
	}
}
