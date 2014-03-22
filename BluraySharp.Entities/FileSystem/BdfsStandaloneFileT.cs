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

using BluraySharp.Common;

namespace BluraySharp.FileSystem
{
	public class BdfsStandaloneFile<T> : BdfsEntryFile<T>, IBdfsEntryFile<T>
		where T : class, IBdmvEntry
	{
		public BdfsStandaloneFile(string path)
		{
			base.Name = path;
		}

		public override string GetBackupPath()
		{
			return null;
		}

		public override string GetFullPath()
		{
			return this.Name;
		}
	}
}
