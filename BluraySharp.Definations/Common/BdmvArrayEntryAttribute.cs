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
	/// <summary>
	/// Attribute indicating a five-figure numbered BDMV entry file, like mpls and clpi
	/// </summary>
	public class BdmvArrayEntryAttribute : BdmvEntryAttribute
	{
		private string folderName;

		/// <summary>
		/// Name of the entries' parent folder
		/// </summary>
		public string FolderName
		{
			get { return folderName; }
			set { folderName = value; }
		}
		
		private int maxSerialNumber;

		/// <summary>
		/// The maximum of the entry file id number.
		/// </summary>
		public int MaxSerialNumber
		{
			get { return maxSerialNumber; }
			set { maxSerialNumber = value; }
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="folderName">Name of the entries' parent folder</param>
		/// <param name="extension">Extension name of the entry file.</param>
		/// <param name="maxSerialNumber">Maximum of files' id number.</param>
		/// <param name="isBackupRequired">Indicating existence of a backup version</param>
		public BdmvArrayEntryAttribute(string folderName, string extension, int maxSerialNumber, bool isBackupRequired)
			: base(extension, isBackupRequired)
		{
			this.folderName = folderName;
			this.maxSerialNumber = maxSerialNumber;
		}
	}
}
