using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnIgCodecInfo : IPlStnCodecInfo
	{
		BdLang Language { get; set; }
	}
}
