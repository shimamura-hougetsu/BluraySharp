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
	public interface IBdfsEntryFile<T> : IBdfsItem
		where T : IBdmvEntry
	{
		void Save(T entry);
		T Load();

		void SaveBackup(T entry);
		T LoadBackup();
	}
}
