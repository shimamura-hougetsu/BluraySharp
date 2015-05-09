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
	[BdmvArrayEntry("PLAYLIST", "mpls", 2000, true)]
	public interface IBdMpls: IBdmvArrayEntry
	{
		string MplsMark { get; }
		string MplsVer { get; set; }

		IPlAppInfo AppInfo { get; }
		IPlPlayItemList PlayItemList { get; }
		IPlPlayMarkList PlayMarkList { get; }
		BluraySharp.Common.BdStandardPart.BdExtensionData ExtensionData { get; set; }
	}
}
