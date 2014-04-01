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
	public interface IPlPlayItem : IPlPlayItemInfo
	{
		BdUOMask UoMask { get; }

		bool RandomAccessFlag { get; set; }
		PlStillMode StillMode { get; set; }
		ushort StillDuration { get; set; }

		bool IsMultiAngleDifferentAudios { get; set; }
		bool IsMultiAngleOptionsSeamlessChange { get; set; }

		IPlStnTable StnTable { get; }
	}
}
