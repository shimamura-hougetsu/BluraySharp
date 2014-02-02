using System.Collections.Generic;

namespace BluraySharp.Playlist
{
	public interface IPlStnTable : IBdPart
	{
		IList<IPlStnRecord> this[PlStnRecordTypes index] { get; }
	}
}
