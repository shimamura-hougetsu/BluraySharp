﻿using System;
using BluraySharp.Common.Serializing;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPClipInfo : IBdPart
	{
		string ClipCodec { get; set; }
		uint ClipId { get; set; }
		string ToString();
	}
}
