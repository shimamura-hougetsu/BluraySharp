using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnPgCodecInfo : IPlStnCodecInfo
	{
		BdLang Language { get; set; }
	}
}
