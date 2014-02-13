using System.Collections.Generic;
using BluraySharp.Architecture;


namespace BluraySharp.PlayList
{
	public interface IPlStnTable : IBdPart
	{
		//Video = 0, //1, 1
		//Audio, // = 1, 0, 32
		//Pg, // = 2, 0, 255
		//Ig, // = 3, 0, 32
		//AudioAlt, // = 4, 0, 32
		//VideoAlt, // = 5, 0, 32
		//PipPg, // = 6, 0, 32
		//Reserved1, // = 7,
		//Reserved2, // = 8,
		//Reserved3, // = 9,
		//Reserved4, // = 10,
		//Reserved5, // = 11,
		//Count

		IBdList<IPlStnViRecord> VStream { get; set; }
		IBdList<IPlStnAuRecord> AStreams { get; }
		IBdList<IPlStnOlRecord> PgTsStreams { get; }
		IBdList<IPlStnOlRecord> IgStreams { get; }
		IBdList<IPlStnSecAuRecord> SaStreams { get; }
		IBdList<IPlStnSecViRecord> SvStreams { get; }
		IBdList<IPlStnOlRecord> PipPgTsStreams { get; }
	}
}
