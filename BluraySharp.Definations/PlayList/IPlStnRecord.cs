﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public interface IPlStnRecord : IBdPart
	{
		PlStnStreamEntryType EntryType { get; set; }
		IPlStnStreamEntry Entry { get; }
	}
}
