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
	[System.ComponentModel.TypeConverter(typeof(BdStreamCodingTypeConverter<BdViCodingType>))]
	public enum BdViCodingType : byte
	{
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown = BdStreamCodingType.Unknown,

		ViMpeg1 = BdStreamCodingType.ViMpeg1,
		ViMpeg2 = BdStreamCodingType.ViMpeg2,

		ViAvc = BdStreamCodingType.ViAvc,
		ViMvc = BdStreamCodingType.ViMvc,
		ViVc1 = BdStreamCodingType.ViVc1,
	}

	[System.ComponentModel.TypeConverter(typeof(BdStreamCodingTypeConverter<BdAuCodingType>))]
	public enum BdAuCodingType : byte
	{
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		
		Unknown = BdStreamCodingType.Unknown,

		AuMpeg1 = BdStreamCodingType.AuMpeg1,
		AuMpeg2 = BdStreamCodingType.AuMpeg2,

		AuLPCM = BdStreamCodingType.AuLPCM,
		AuDolby = BdStreamCodingType.AuDolby,
		AuDts = BdStreamCodingType.AuDts,

		AuDolbyLossless = BdStreamCodingType.AuDolbyLossless,
		AuDolbyPlus = BdStreamCodingType.AuDolbyPlus,

		AuDtsHDHR = BdStreamCodingType.AuDtsHDHR,
		AuDtsHDMA = BdStreamCodingType.AuDtsHDMA,
	}

	[System.ComponentModel.TypeConverter(typeof(BdStreamCodingTypeConverter<BdStCodingType>))]
	public enum BdStCodingType : byte	//subtitle
	{
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown = BdStreamCodingType.Unknown,

		GxPresentation = BdStreamCodingType.GxPresentation,
		TxSubtitle = BdStreamCodingType.TxSubtitle,
	}

	[System.ComponentModel.TypeConverter(typeof(BdStreamCodingTypeConverter<BdIgCodingType>))]
	public enum BdIgCodingType : byte
	{
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown = BdStreamCodingType.Unknown,

		GxInterractive = BdStreamCodingType.GxInterractive,
	}

	[System.ComponentModel.TypeConverter(typeof(BdStreamCodingTypeConverter<BdSaCodingType>))]
	public enum BdSaCodingType : byte
	{
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown = BdStreamCodingType.Unknown,

		SaDolbyPlus = BdStreamCodingType.SaDolbyPlus,
		SaDtsHD = BdStreamCodingType.SaDtsHD,
	}

	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<BdStreamCodingType>))]
	public enum BdStreamCodingType : byte
	{
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown,

		ViMpeg1 = 0x01,
		ViMpeg2 = 0x02,

		ViAvc = 0x1B,
		ViMvc = 0x20,
		ViVc1 = 0xEA,

		AuMpeg1 = 0x03,
		AuMpeg2 = 0x04,

		AuLPCM = 0x80,
		AuDolby = 0x81,
		AuDts = 0x82,

		AuDolbyLossless = 0x83,
		AuDolbyPlus = 0x84,
		AuDtsHDHR = 0x85,
		AuDtsHDMA = 0x86,

		GxPresentation = 0x90,
		GxInterractive = 0x91,

		TxSubtitle = 0x92,

		SaDolbyPlus = 0xA1,
		SaDtsHD = 0xA2,
	}
}
