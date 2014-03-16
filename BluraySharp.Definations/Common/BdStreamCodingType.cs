
namespace BluraySharp.Common
{
	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<BdViCodingType>))]
	public enum BdViCodingType
	{
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown,
		ViMpeg1 = 0x01,
		ViMpeg2 = 0x02,

		ViAvc = 0x1B,
		ViMvc = 0x20,
		ViVc1 = 0xEA,
	}

	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<BdAuCodingType>))]
	public enum BdAuCodingType
	{
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown,
		AuMpeg1 = 0x03,
		AuMpeg2 = 0x04,

		AuLPCM = 0x80,
		AuDolby = 0x81,
		AuDts = 0x82,

		AuDolbyLossless = 0x83,
		AuDolbyPlus = 0x84,
		AuDtsHDHR = 0x85,
		AuDtsHDMA = 0x86,
	}

	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<BdStCodingType>))]
	public enum BdStCodingType	//subtitle
	{
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown,
		GxPresentation = 0x90,
		TxSubtitle = 0x92,
	}

	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<BdIgCodingType>))]
	public enum BdIgCodingType
	{
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown,
		GxInterractive = 0x91,
	}

	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<BdSaCodingType>))]
	public enum BdSaCodingType
	{
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown,
		SaDolbyPlus = 0xA1,
		SaDtsHD = 0xA2,
	}
}
