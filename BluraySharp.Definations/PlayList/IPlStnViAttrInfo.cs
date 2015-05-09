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

using System;
using BluraySharp.Common.Serializing;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnViAttrInfo : IPlStnAttrInfo
	{
		BdViFormat VideoFormat { get; set; }
		BdViFrameRate FrameRate { get; set; }
	}
}
