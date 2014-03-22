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


namespace BluraySharp.ClipInfo
{
	/// <summary>
	/// Extra properties for clips of Mpeg2 Transport Stream type
	/// </summary>
	public interface ICiTsTypeInfo : BluraySharp.Common.IBdPart
	{
		/// <summary>
		/// Unknown, always 0x80
		/// </summary>
		byte ValidityFlags { get; set;}
		/// <summary>
		/// Unknown, always "HDMV"
		/// </summary>
		string FormatIdentifier { get; set; }
		/// <summary>
		/// Unknown, filled with 0
		/// </summary>
		string NetworkInformation { get; set; }
		/// <summary>
		/// Unknown, filled with 0
		/// </summary>
		string StreamFormatName { get; set; }
	}
}
