using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Playlist
{
	public enum PlStnRecordTypes : byte
	{
		Video = 0, //1, 1
		Audio, // = 1, 0, 32
		Pg, // = 2, 0, 255
		Ig, // = 3, 0, 32
		AudioAlt, // = 4, 0, 32
		VideoAlt, // = 5, 0, 32
		PipPg, // = 6, 0, 32
		Reserved1, // = 7,
		Reserved2, // = 8,
		Reserved3, // = 9,
		Reserved4, // = 10,
		Reserved5, // = 11,
		Count
	}
}
