﻿using System;

namespace BluraySharp.PlayList
{
	public class PlStnRecordStreamInfo : IBdRawSerializable
	{
		public long SerializeTo(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(BdRawSerializeContext context)
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
