using BluraySharp.Common;
using BluraySharp.Common.Serializing;

namespace BluraySharp.PlayList
{
	public interface IPlStnTable : IBdPart
	{
		IBdList<IPlStnViEntry> ViStreams { get; }
		IBdList<IPlStnAuEntry> AuStreams { get; }
		IBdList<IPlStnStEntry> StStreams { get; }
		IBdList<IPlStnIgEntry> IgStreams { get; }
		IBdList<IPlStnSaEntry> SaStreams { get; }
		IBdList<IPlStnSvEntry> SvStreams { get; }
		IBdList<IPlStnStEntry> PipStStreams { get; }
	}
}
