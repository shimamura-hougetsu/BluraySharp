﻿using System;
using BluraySharp.Architecture;

namespace BluraySharp.Playlist
{
	public class PlStnRecordCodecInfo : BluraySharp.Playlist.IPlStnRecordCodecInfo
	{
		public long SerializeTo(IBdRawIoContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawIoContext context)
		{
			byte tDataLen;
			tDataLen = context.DeserializeByte();

			return context.Offset += tDataLen;
		}

		public long RawLength
		{
			get { throw new NotImplementedException(); }
		}
	}
}
