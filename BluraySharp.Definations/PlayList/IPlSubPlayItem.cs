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

using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	/// <summary>
	/// PlayItems in a <see cref="IPlSubPath"/>
	/// </summary>
	public interface IPlSubPlayItem : IPlPlayItemInfo
	{
		/// <summary>
		/// Get or Set Id of a PlayItem as timeline reference
		/// </summary>
		ushort SyncPlayItemId { get; set; }
		/// <summary>
		/// Get or Set the timestamp where the synchronization starts.
		/// </summary>
		BdTime SyncPlayTime { get; set; }
	}
}
