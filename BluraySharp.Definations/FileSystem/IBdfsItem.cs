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

using System.Collections.Generic;
using System.IO;

namespace BluraySharp.FileSystem
{
	public interface IBdfsItem : IEnumerable<IBdfsItem>
	{
		string Name { get; set; }

		FileSystemInfo DetailedInfo { get; }
		IBdfsAttribute Attribute { get; }

		IBdfsItem Parent { get; }
		IEnumerable<IBdfsItem> Children { get; }
		
		string GetFullPath();
		string GetBackupPath();
	}
}
