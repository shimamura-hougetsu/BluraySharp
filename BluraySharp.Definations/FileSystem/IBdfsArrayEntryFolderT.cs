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
using BluraySharp.Common;

namespace BluraySharp.FileSystem
{
	public interface IBdfsArrayEntryFolder<T> : IBdfsFolder<IBdfsArrayEntryFile<T>>
		where T : IBdmvArrayEntry
	{
		T CreateFileContext(uint id);
		IBdList<IBdfsArrayEntryFile<T>> Files { get; }
	}
}
