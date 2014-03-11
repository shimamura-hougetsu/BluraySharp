using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnGxCodecInfo : IPlStnCodecInfo
	{
		BdLang Language { get; set; }
	}
}
