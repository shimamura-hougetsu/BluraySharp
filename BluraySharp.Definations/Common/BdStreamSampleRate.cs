﻿/* ****************************************************************************
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


namespace BluraySharp.Common
{
	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<BdViFrameRate>))]
	public enum BdViFrameRate
	{
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown = 0x00,

		Vi23 = 0x01,
		Vi24 = 0x02,
		Vi25 = 0x03,
		Vi29 = 0x04,
		Vi50 = 0x06,
		Vi59 = 0x07
	}

	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<BdAuSampleRate>))]
	public enum BdAuSampleRate
	{
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown = 0x00,

		Au48 = 0x01,
		Au96 = 0x04,
		Au192 = 0x05,
		Au48_192 = 0x0C,
		Au48_96 = 0x0E
	}
}
