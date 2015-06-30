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
	/// Video frame rate types
	/// </summary>
	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<BdViFrameRate>))]
	public enum BdViFrameRate
	{
		/// <summary>
		/// Unknown (Reserved)
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown = 0x00,

		/// <summary>
		/// FPS 23.976
		/// </summary>
		Vi23 = 0x01,
		/// <summary>
		/// FPS 24
		/// </summary>
		Vi24 = 0x02,
		/// <summary>
		/// FPS 25
		/// </summary>
		Vi25 = 0x03,
		/// <summary>
		/// FPS 29.97
		/// </summary>
		Vi29 = 0x04,
		//Vi30 = 0x05,
		/// <summary>
		/// FPS 50
		/// </summary>
		Vi50 = 0x06,
		/// <summary>
		/// FPS 59.94
		/// </summary>
		Vi59 = 0x07,
		//Vi60 = 0x08,
	}

	/// <summary>
	/// Audio sample rate types
	/// </summary>
	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<BdAuSampleRate>))]
	public enum BdAuSampleRate
	{
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown = 0x00,

		/// <summary>
		/// 48,000 Hz
		/// </summary>
		Au48 = 0x01,
		/// <summary>
		/// 96,000 Hz
		/// </summary>
		Au96 = 0x04,
		/// <summary>
		/// 192,000 Hz
		/// </summary>
		Au192 = 0x05,

		/// <summary>
		/// 48kHz and 192kHz Combo
		/// </summary>
		Au48_192 = 0x0C,
		/// <summary>
		/// 48kHz and 96kHz Combo
		/// </summary>
		Au48_96 = 0x0E
	}
}
