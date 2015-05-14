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


using BluraySharp.Common;
namespace BluraySharp.ClipInfo
{
	/// <summary>
	/// Extra properties for clips of Mpeg2 Transport Stream type
	/// </summary>
	public interface ICiTsTypeInfo : IBdPart
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
