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

namespace BluraySharp.Common
{
	public interface IBdmvEntryRegistry
	{
		T CreateEntry<T>() where T : class, IBdmvEntry;
		BdmvEntryAttribute GetEntryAttribute<T>() where T : class, IBdmvEntry;
	}
}
