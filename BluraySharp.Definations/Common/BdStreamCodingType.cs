
namespace BluraySharp.Common
{
	public enum BdViCodingType
	{
		Unknown,
		ViMpeg1 = 0x01,
		ViMpeg2 = 0x02,

		ViAvc = 0x1B,
		ViMvc = 0x20,
		ViVc1 = 0xEA,
	}

	public enum BdAuCodingType
	{
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

	public enum BdStCodingType	//subtitle
	{
		Unknown,
		GxPresentation = 0x90,
		TxSubtitle = 0x92,
	}

	public enum BdIgCodingType
	{
		Unknown,
		GxInterractive = 0x91,
	}

	public enum BdSaCodingType
	{
		Unknown,
		SaDolbyPlus = 0xA1,
		SaDtsHD = 0xA2,
	}
}
