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


namespace BluraySharp.PlayList
{
	/// <summary>
	/// Properties of STN Entry refering a stream from a SubPlayItem
	/// </summary>
	public interface IPlStnSubPlayItemEntryInfo : IPlStnEntryInfo
	{
		/// <summary>
		/// Id of SubPath
		/// </summary>
		byte SubPathId { get; set; }

		/// <summary>
		/// Id of SubPlayItem in SubPath
		/// </summary>
		byte SubPlayItemId { get; set; }

		/// <summary>
		/// Program Id of stream in SubPlayItem
		/// </summary>
		ushort StreamProgId { get; set; }
	}
}
