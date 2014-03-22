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


namespace BluraySharp.Common
{
	/// <summary>
	/// Video stream coding types
	/// </summary>
	[System.ComponentModel.TypeConverter(typeof(BdStreamCodingTypeConverter<BdViCodingType>))]
	public enum BdViCodingType : byte
	{
		/// <summary>
		/// Unknown (Reserved)
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown = BdStreamCodingType.Unknown,

		/// <summary>
		/// MPEG-1
		/// </summary>
		ViMpeg1 = BdStreamCodingType.ViMpeg1,
		/// <summary>
		/// MPEG-2
		/// </summary>
		ViMpeg2 = BdStreamCodingType.ViMpeg2,

		/// <summary>
		/// MPEG-4 (AVC)
		/// </summary>
		ViAvc = BdStreamCodingType.ViAvc,
		/// <summary>
		/// Multi-view Video Coding
		/// </summary>
		ViMvc = BdStreamCodingType.ViMvc,
		/// <summary>
		/// Microsoft Video Codec 1
		/// </summary>
		ViVc1 = BdStreamCodingType.ViVc1,
	}

	/// <summary>
	/// Audio stream coding types
	/// </summary>
	[System.ComponentModel.TypeConverter(typeof(BdStreamCodingTypeConverter<BdAuCodingType>))]
	public enum BdAuCodingType : byte
	{
		/// <summary>
		/// Unknown (Reserved)
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown = BdStreamCodingType.Unknown,

		/// <summary>
		/// MPEG-1
		/// </summary>
		AuMpeg1 = BdStreamCodingType.AuMpeg1,
		/// <summary>
		/// MPEG-2
		/// </summary>
		AuMpeg2 = BdStreamCodingType.AuMpeg2,

		/// <summary>
		/// Linear PCM
		/// </summary>
		AuLPCM = BdStreamCodingType.AuLPCM,
		/// <summary>
		/// Dolby Digital (AC3)
		/// </summary>
		AuDolby = BdStreamCodingType.AuDolby,
		/// <summary>
		/// DTS
		/// </summary>
		AuDts = BdStreamCodingType.AuDts,

		/// <summary>
		/// Dolby Lossless (TrueHD)
		/// </summary>
		AuDolbyLossless = BdStreamCodingType.AuDolbyLossless,
		/// <summary>
		/// Dolby Digital Plus (AC3+)
		/// </summary>
		AuDolbyPlus = BdStreamCodingType.AuDolbyPlus,

		/// <summary>
		/// DTS-HD High Resolution Audio
		/// </summary>
		AuDtsHDHR = BdStreamCodingType.AuDtsHDHR,
		/// <summary>
		/// DTS-HD Master Audio
		/// </summary>
		AuDtsHDMA = BdStreamCodingType.AuDtsHDMA,
	}

	/// <summary>
	/// Subtitle stream coding types
	/// </summary>
	[System.ComponentModel.TypeConverter(typeof(BdStreamCodingTypeConverter<BdStCodingType>))]
	public enum BdStCodingType : byte
	{
		/// <summary>
		/// Unknown (Reserved)
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown = BdStreamCodingType.Unknown,

		/// <summary>
		/// Presentation Graphics
		/// </summary>
		GxPresentation = BdStreamCodingType.GxPresentation,
		/// <summary>
		/// Text Subtitle
		/// </summary>
		TxSubtitle = BdStreamCodingType.TxSubtitle,
	}

	/// <summary>
	/// Interractive Graphics stream coding types
	/// </summary>
	[System.ComponentModel.TypeConverter(typeof(BdStreamCodingTypeConverter<BdIgCodingType>))]
	public enum BdIgCodingType : byte
	{
		/// <summary>
		/// Unknown (Reserved)
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown = BdStreamCodingType.Unknown,

		/// <summary>
		/// Interractive Graphics
		/// </summary>
		GxInterractive = BdStreamCodingType.GxInterractive,
	}

	/// <summary>
	/// Secondary audio stream coding types
	/// </summary>
	[System.ComponentModel.TypeConverter(typeof(BdStreamCodingTypeConverter<BdSaCodingType>))]
	public enum BdSaCodingType : byte
	{
		/// <summary>
		/// Unknown (Reserved)
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown = BdStreamCodingType.Unknown,

		/// <summary>
		/// Dolby Digital Plus (AC3+) for secondary audio
		/// </summary>
		SaDolbyPlus = BdStreamCodingType.SaDolbyPlus,
		/// <summary>
		/// DTS-HD Low Bitrate for secondary audio
		/// </summary>
		SaDtsHD = BdStreamCodingType.SaDtsHD,
	}

	/// <summary>
	/// Stream coding types
	/// </summary>
	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<BdStreamCodingType>))]
	public enum BdStreamCodingType : byte
	{
		/// <summary>
		/// Unknown (Reserved)
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown,

		/// <summary>
		/// MPEG-1 Video
		/// </summary>
		ViMpeg1 = 0x01,
		/// <summary>
		/// MPEG-2 Video
		/// </summary>
		ViMpeg2 = 0x02,

		/// <summary>
		/// MPEG-4 Video (AVC)
		/// </summary>
		ViAvc = 0x1B,
		/// <summary>
		/// Multi-view Video Coding
		/// </summary>
		ViMvc = 0x20,
		/// <summary>
		/// Microsoft Video Codec 1
		/// </summary>
		ViVc1 = 0xEA,

		/// <summary>
		/// MPEG-1 Audio
		/// </summary>
		AuMpeg1 = 0x03,
		/// <summary>
		/// MPEG-2 Audio
		/// </summary>
		AuMpeg2 = 0x04,

		/// <summary>
		/// Linear PCM Audio
		/// </summary>
		AuLPCM = 0x80,
		/// <summary>
		/// Dolby Digital (AC3) Audio
		/// </summary>
		AuDolby = 0x81,
		/// <summary>
		/// DTS Audio
		/// </summary>
		AuDts = 0x82,

		/// <summary>
		/// Dolby Lossless (TrueHD) Audio
		/// </summary>
		AuDolbyLossless = 0x83,
		/// <summary>
		/// Dolby Digital Plus (AC3+) Audio
		/// </summary>
		AuDolbyPlus = 0x84,
		/// <summary>
		/// DTS-HD High Resolution Audio
		/// </summary>
		AuDtsHDHR = 0x85,
		/// <summary>
		/// DTS-HD Master Audio
		/// </summary>
		AuDtsHDMA = 0x86,

		/// <summary>
		/// Presentation graphics
		/// </summary>
		GxPresentation = 0x90,
		/// <summary>
		/// Interractive graphics
		/// </summary>
		GxInterractive = 0x91,

		/// <summary>
		/// Text Subtitle
		/// </summary>
		TxSubtitle = 0x92,

		/// <summary>
		/// Dolby Digital Plus (AC3+) for secondary audio
		/// </summary>
		SaDolbyPlus = 0xA1,
		/// <summary>
		/// DTS-HD Low Bitrate for secondary audio
		/// </summary>
		SaDtsHD = 0xA2,
	}
}
