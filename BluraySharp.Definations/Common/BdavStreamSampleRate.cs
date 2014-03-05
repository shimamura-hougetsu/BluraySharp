
namespace BluraySharp.Common
{
	public enum BdViFrameRate
	{
		Unknown,
		Vi23 = 0x01,
		Vi24 = 0x02,
		Vi25 = 0x03,
		Vi29 = 0x04,
		Vi50 = 0x06,
		Vi59 = 0x07
	}

	public enum BdAuSampleRate
	{
		Unknown,
		Au48 = 0x01,
		Au96 = 0x04,
		Au192 = 0x05,
		Au48_192 = 0x0C,
		Au48_96 = 0x0E
	}
}
