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
	/// Indicating size of a UInt BdPart field.
	/// </summary>
	public enum BdIntSize : byte
	{
		/// <summary>
		/// Default value.
		/// </summary>
		None = 0,

		/// <summary>
		/// Byte
		/// </summary>
		BYTE = 1,
		/// <summary>
		/// Word (2 Bytes)
		/// </summary>
		WORD = 2,
		/// <summary>
		/// Double Word (4 Bytes)
		/// </summary>
		DWORD = 4,
		/// <summary>
		/// Quadruple Word (8 Bytes)
		/// </summary>
		QWORD = 8,

		/// <summary>
		/// 8 bits (1 Byte)
		/// </summary>
		U8 = 1,
		/// <summary>
		/// 16 bits (2 Bytes)
		/// </summary>
		U16 = 2,
		/// <summary>
		/// 32 bits (4 Bytes)
		/// </summary>
		U32 = 4,
		/// <summary>
		/// 64 bits (8 Bytes)
		/// </summary>
		U64 = 8,

		/// <summary>
		/// Automatically decides (Reserved)
		/// </summary>
		Auto = 255
	}
}
