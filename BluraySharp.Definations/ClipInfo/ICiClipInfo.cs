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
	public interface ICiClipInfo : IBdPart
	{
		CiTsType StreamType { get; }
		CiApplicationType ApplicationType { get; set; }

		//bool IsAtcDelta { get; set; }
		uint TsRecodingRate { get; set; }
		uint SourcePacketsCount { get; set; }

		ICiTsTypeInfo TsTypeInfo { get; }
		IBdList<ICiAtcDeltaEntry> AtcDeltaList { get; }

		IBdList<uint> PresentationEndTime27MHz { get; }

		IBdList<ICiAppFontRef> AppFontRefList { get; }
	}
}
