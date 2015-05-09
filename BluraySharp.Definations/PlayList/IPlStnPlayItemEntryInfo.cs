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


namespace BluraySharp.PlayList
{
	/// <summary>
	/// Properties of STN Entry refering a stream from PlayItem
	/// </summary>
	public interface IPlStnPlayItemEntryInfo : IPlStnEntryInfo
	{
		/// <summary>
		/// Program Id of stream in PlayItem
		/// </summary>
		ushort StreamProgId { get; set; }
	}
}
