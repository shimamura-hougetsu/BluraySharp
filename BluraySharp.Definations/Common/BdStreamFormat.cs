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


namespace BluraySharp.Common
{
	/// <summary>
	/// Video format types
	/// </summary>
	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<BdViFormat>))]
	public enum BdViFormat
	{
		/// <summary>
		/// Unknown (Reserved)
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown,

		/// <summary>
		/// 480 Interlaced
		/// </summary>
		Vi480i = 0x01,
		/// <summary>
		/// 576 Interlaced
		/// </summary>
		Vi576i = 0x02,
		/// <summary>
		/// 480 Progressive
		/// </summary>
		Vi480p = 0x03,
		/// <summary>
		/// 1080 Interlaced
		/// </summary>
		Vi1080i = 0x04,
		/// <summary>
		/// 720 Progressive
		/// </summary>
		Vi720p = 0x05,
		/// <summary>
		/// 1080 Progressive
		/// </summary>
		Vi1080p = 0x06,
		/// <summary>
		/// 576 Progressive
		/// </summary>
		Vi576p = 0x07
	}

	/// <summary>
	/// Audio presentation types
	/// </summary>
	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<BdAuPresentationType>))]
	public enum BdAuPresentationType
	{
		/// <summary>
		/// Unknown (Reserved)
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown,

		/// <summary>
		/// Mono
		/// </summary>
		Mono = 0x01,

		//DualMono = 0x02,

		/// <summary>
		/// Stereo
		/// </summary>
		Stereo = 0x03,

		/// <summary>
		/// Multi-channel
		/// </summary>
		Multi = 0x06,

		/// <summary>
		/// Stereo and Multi-channel Combo
		/// </summary>
		Combo = 0x0C
	}

	/// <summary>
	/// Text subtitle character coding types
	/// </summary>
	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<BdCharacterCodingType>))]
	public enum BdCharacterCodingType
	{
		/// <summary>
		/// Unknown (Reserved)
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown,

		/// <summary>
		/// Unicode (UTF-8)
		/// </summary>
		UTF8 = 0x01,
		/// <summary>
		/// Unicode (UTF-16 Big Ending)
		/// </summary>
		UTF16BE = 0x02,

		//ShiftJis = 0x03,
		//KSC5601 = 0x04,
		//GB18030 = 0x05,
		//GB2312 = 0x06,
		//BIG5 = 0x07
	}
}
