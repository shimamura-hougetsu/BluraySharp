﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public enum PlPlaybackType : byte
	{
		Unknown = 0x00,

		Sequential = 1,
		Random = 2,
		Shuffle = 3,
	}
}
