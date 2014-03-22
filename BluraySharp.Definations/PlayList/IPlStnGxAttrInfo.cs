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
	/// <summary>
	/// Properties of a STN Entry refering a graphics stream
	/// </summary>
	public interface IPlStnGxAttrInfo : IPlStnAttrInfo
	{
		/// <summary>
		/// Get or Set language of the graphics' contents.
		/// </summary>
		BdLang Language { get; set; }
	}
}
