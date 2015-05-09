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
	/// Properties of STN Entry refering a PiP stream from a PiP SubPath
	/// </summary>
	public interface IPlStnInMuxPipEntryInfo : IPlStnEntryInfo
	{
		/// <summary>
		/// Id of a PiP SubPath
		/// </summary>
		byte SubPathId { get; set; }

		/// <summary>
		/// Id of a PiP stream in SubPath items
		/// </summary>
		ushort StreamProgId { get; set; }
	}
}
