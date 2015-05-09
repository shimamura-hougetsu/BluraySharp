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

namespace BluraySharp.Common
{
	/// <summary>
	/// Attribute indicating a BDMV file with .bdmv extension.
	/// </summary>
	internal class BdmvTopEntryAttribute : BdmvEntryAttribute
	{
		private string filename;

		/// <summary>
		/// File name of the entry.
		/// e.g. index, MovieObject and sound
		/// </summary>
		public string FileName
		{
			get { return filename; }
			set { filename = value; }
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="filename">File name of the top entry</param>
		/// <param name="isBackupRequired">Indicating existence of a backup version</param>
		public BdmvTopEntryAttribute(string filename, bool isBackupRequired)
			: base("bdmv", isBackupRequired)
		{
			this.filename = filename;
		}
	}
}
