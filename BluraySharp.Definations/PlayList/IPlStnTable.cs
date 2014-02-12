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

		IList<IPlStnViRecord> VStream { get; set; }
		IList<IPlStnAudioRecord> AStreams { get; }
		IList<IPlStnOlRecord> PgTsStreams { get; }
		IList<IPlStnSecVideoRecord> SvStreams { get; }
		IList<IPlStnSecAuRecord> SaStreams { get; }
	}
}
