using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common
{
	public class BdmvTopEntryAttribute : BdmvEntryAttribute
	{
		private string filename;
		public string FileName
		{
			get { return filename; }
			set { filename = value; }
		}

		public BdmvTopEntryAttribute(string filename, bool isBackupRequired)
			: base("bdmv", isBackupRequired)
		{
			this.filename = filename;
		}
	}
}
