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
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.ClipInfo
{
	public interface ICiStreamViAttrInfo : ICiStreamAttrInfo
	{
		BdViFormat Format { get; set; }
		BdViFrameRate FrameRate { get; set; }
		BdViAspectRatio AspectRatio { get; set; }
		bool CcFlag { get; set; }
	}
}
