using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnSvEntry : IPlStnEntry
	{
		IBdList<byte> SecondaryAudioIdRef { get; }
		IBdList<byte> PipSubtitleIdRef { get; }
	}
}
