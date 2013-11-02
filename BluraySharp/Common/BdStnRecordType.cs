using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common
{
	public enum StnRecordTypes : byte
	{
		Video = 0,
		Audio = 1,
		Pg = 2,
		Ig = 3,
		AudioAlt = 4,
		VideoAlt = 5,
		PipPg = 6,
		Reserved1 = 7,
		Reserved2 = 8,
		Reserved3 = 9,
		Reserved4 = 10,
		Reserved5 = 11,
		Count
	}
}
