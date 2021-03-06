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
	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<PlStillModeType>))]
	public enum PlStillModeType
	{
		NotStill = 0x0,
		StillForDuration = 0x1,
		StillInfinitely = 0x2,
	}
}
