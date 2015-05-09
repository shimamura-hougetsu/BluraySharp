/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at BitBucket (https://bitbucket.org/subelf/bluraysharp)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/

using System;

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
