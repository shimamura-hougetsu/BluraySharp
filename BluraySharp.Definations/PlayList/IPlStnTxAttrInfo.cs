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

namespace BluraySharp.PlayList
{
	/// <summary>
	/// Attribute Properties of a STN Entry refering a text subtitle stream
	/// </summary>
	public interface IPlStnTxAttrInfo : IPlStnAttrInfo
	{
		/// <summary>
		/// Get or Set char-coding format of the text
		/// </summary>
		BdCharacterCodingType CharCode { get; set; }

		/// <summary>
		/// Get or Set language of the text
		/// </summary>
		BdLang Language { get; set; }
	}
}
