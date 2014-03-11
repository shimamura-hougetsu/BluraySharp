using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common
{
	[AttributeUsage(AttributeTargets.Interface, AllowMultiple=false, Inherited=true)]
	public class BdmvEntryAttribute : Attribute
	{
		private bool isBackupRequired;

		public bool IsBackupRequired
		{
			get { return isBackupRequired; }
			set { isBackupRequired = value; }
		}

		private string extension;

		public string Extension
		{
			get { return extension; }
			set { extension = value; }
		}

		public BdmvEntryAttribute(string extension, bool isBackupRequired)
		{
			this.extension = extension;
			this.isBackupRequired = isBackupRequired;
		}
	}
}
