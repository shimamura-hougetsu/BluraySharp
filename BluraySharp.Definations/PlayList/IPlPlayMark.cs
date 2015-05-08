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
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public interface IPlPlayMark : IBdPart
	{
		PlPlayMarkType MarkType { get; set; }
		ushort PlayItemId { get; set; }
		BdTime TimeStamp { get; set; }
		ushort StreamProgId { get; set; }
		uint Duration { get; set; }
	}
}
