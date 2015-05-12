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
	[BdmvArrayEntry("CLIPINF", "clpi", 100000, true)]
	public interface IBdClpi : IBdmvArrayEntry
	{
		string ClpiMark { get; }
		string ClpiVer { get; set; }

		ICiClipInfo ClipInfo { get; }

		ICiSequenceInfo SequenceInfo { get; }

		ICiProgramInfo ProgramInfo { get; }

		ICiCpi Cpi { get; }

		ICiClipMark ClipMark { get; }

		BluraySharp.Common.BdStandardPart.BdExtensionData ExtensionData { get; set; }
	}
}
