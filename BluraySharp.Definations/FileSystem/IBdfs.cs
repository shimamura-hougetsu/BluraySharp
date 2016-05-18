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

using System.Collections.Generic;
using System.IO;

namespace BluraySharp.FileSystem
{
	public interface IBdfs
	{
		bool IsFileExist(string name);
		bool IsFolderExist(string name);
		Stream OpenFile(string name, FileMode mode, FileAccess access);
	}
}
