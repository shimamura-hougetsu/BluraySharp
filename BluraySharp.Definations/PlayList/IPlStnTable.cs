using System.Collections.Generic;

namespace BluraySharp.Playlist
{
	public interface IPlStnTable : IBdObject
	{
		IList<IPlStnRecord> this[PlStnRecordTypes index] { get; }
	}
}
