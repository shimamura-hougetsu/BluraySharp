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
	public interface ICiTsTypeInfo : BluraySharp.Common.IBdPart
	{
		byte ValidityFlags { get; set;}
		string FormatIdentifier { get; set; }
		string NetworkInformation { get; set; }
		string StreamFormatName { get; set; }
	}
}
