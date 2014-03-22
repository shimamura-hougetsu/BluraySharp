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

namespace BluraySharp.PlayList
{
	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<PlStnEntryType>))]
	public enum PlStnEntryType : byte
	{
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown,

		/// <summary>
		/// Stream from PlayItem
		/// </summary>
		PlayItem = 0x01,

		/// <summary>
		/// Stream from SubPath.SubPlayItem
		/// </summary>
		SubPlayItem = 0x02,

		/// <summary>
		/// Stream as Pip from PlayItem
		/// </summary>
		InMuxPip = 0x03,

	}
}
