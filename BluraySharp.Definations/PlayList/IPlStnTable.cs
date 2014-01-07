using System.Collections.Generic;

namespace BluraySharp.Playlist
{
	public interface IPlStnTable : IBdRawSerializable
	{
		IList<IPlStnRecord> this[PlStnRecordTypes index] { get; }
	}
}
