﻿using System;

namespace BluraySharp.Playlist
{
	public class PlStnRecord : IBdRawSerializable
	{
		public PlStnRecordStreamInfo StreamInfo { get; private set; }
		public PlStnRecordCodecInfo CodecInfo { get; private set; }

		public long SerializeTo(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			StreamInfo = context.Deserialize<PlStnRecordStreamInfo>();
			CodecInfo = context.Deserialize<PlStnRecordCodecInfo>();

			return context.Offset;
		}

		public long RawLength
		{
			get
			{
				return StreamInfo.RawLength + CodecInfo.RawLength;
			}
		}
	}
}