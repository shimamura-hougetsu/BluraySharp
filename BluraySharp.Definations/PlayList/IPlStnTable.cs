using BluraySharp.Common;
using BluraySharp.Common.Serializing;

namespace BluraySharp.PlayList
{
	public interface IPlStnTable : IBdPart
	{
		IBdList<IPlStnViEntry> ViEntries { get; }
		IBdList<IPlStnAuEntry> AuEntries { get; }
		IBdList<IPlStnStEntry> StEntries { get; }
		IBdList<IPlStnIgEntry> IgEntries { get; }
		IBdList<IPlStnSaEntry> SaEntries { get; }
		IBdList<IPlStnSvEntry> SvEntries { get; }
		IBdList<IPlStnStEntry> PipStEntries { get; }
	}
}
