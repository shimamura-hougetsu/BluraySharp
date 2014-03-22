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

using System;
using BluraySharp.Common;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public interface IPlAppInfo : IBdPart
	{
		BluraySharp.PlayList.PlPlaybackType PlaybackType { get; set; }
		ushort PlaybackCount { get; set; }

		BdUOMask UoMask { get; }

		bool AudioMixAppFlag { get; set; }
		bool LosslessMayBypassMixer { get; set; }
		bool RandomAccessFlag { get; set; }
	}
}