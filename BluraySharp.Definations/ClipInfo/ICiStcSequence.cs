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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.ClipInfo
{
	public interface ICiStcSequence : IBdPart
	{
		ushort PcrPid { get; set; }
		uint SpnStcStart { get; set; }
		BdTime PresentationStartTime { get; set; }
		BdTime PresentationEndTime { get; set; }
	}
}
