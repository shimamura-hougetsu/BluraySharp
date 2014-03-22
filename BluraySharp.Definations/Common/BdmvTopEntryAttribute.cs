/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at Google Code (https://code.google.com/p/bluray-sharp/)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/

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
