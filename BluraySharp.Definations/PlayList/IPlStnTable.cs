using System.Collections.Generic;
using BluraySharp.Architecture;


namespace BluraySharp.Playlist
{
	public interface IPlStnTable : IBdPart
	{
		IList<IPlStnRecord> this[PlStnRecordTypes index] { get; }
	}
}
