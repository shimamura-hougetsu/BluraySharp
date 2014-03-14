
namespace BluraySharp.Common
{
	public enum BdViFormat
	{
		Unknown,

		Vi480i = 0x01,
		Vi576i = 0x02,
		Vi480p = 0x03,
		Vi1080i = 0x04,
		Vi720p = 0x05,
		Vi1080p = 0x06,
		Vi576p = 0x07
	}

	public enum BdAuPresentationType
	{
		Unknown,

		Mono = 0x01,
		//DualMono = 0x02,
		Stereo = 0x03,
		Multi = 0x06,
		Combo = 0x0C
	}

	public enum BdCharacterCodingType
	{
		Unknown,

		UTF8 = 0x01,
		UTF16BE = 0x02,

		//ShiftJis = 0x03,
		//KSC5601 = 0x04,
		//GB18030 = 0x05,
		//GB2312 = 0x06,
		//BIG5 = 0x07
	}
}
