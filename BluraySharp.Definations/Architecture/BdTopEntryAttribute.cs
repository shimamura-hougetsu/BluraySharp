using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Architecture
{
	public class BdTopEntryAttribute : BdComponentEntryAttribute
	{
		private string filename;
		public string FileName
		{
			get { return filename; }
			set { filename = value; }
		}

		public BdTopEntryAttribute(string filename, bool isBackupRequired)
			: base("bdmv", isBackupRequired)
		{
			this.filename = filename;
		}
	}
}
