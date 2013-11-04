using System.Collections.Generic;

namespace BluraySharp.Playlist
{
	public interface IPlStnTable
	{
		IList<PlStnRecord> this[PlStnRecordTypes index] { get; }
	}
}
