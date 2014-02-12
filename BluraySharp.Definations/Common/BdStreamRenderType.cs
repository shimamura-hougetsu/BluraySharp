
namespace BluraySharp.Common
{
	public enum BdViRenderingType
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

	public enum BdAuRenderingType
	{
		Unknown,
		Mono = 0x01,
		Stereo = 0x03,
		Multi = 0x06,
		Combo = 0x0C
	}
}
