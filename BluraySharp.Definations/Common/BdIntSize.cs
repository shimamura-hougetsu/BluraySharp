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
	public enum BdIntSize : byte
	{
		None = 0,

		BYTE = 1,
		WORD = 2,
		DWORD = 4,
		QWORD = 8,

		U8 = 1,
		U16 = 2,
		U32 = 4,
		U64 = 8,

		Auto = 255
	}
}
