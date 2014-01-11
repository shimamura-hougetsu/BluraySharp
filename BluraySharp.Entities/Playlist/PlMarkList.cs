﻿using System;

namespace BluraySharp.Playlist
{
	public class PlMarkList : BluraySharp.Playlist.IPlMarkList
	{
		private byte[] value = new byte[0];

		public long SerializeTo(IBdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawSerializeContext context)
		{
			uint tDataLen;

			tDataLen = context.DeserializeUInt32();

			if (tDataLen > 0)
			{
				context.EnterScope(tDataLen);

				try
				{
					value = context.DeserializeBytes((int)tDataLen);
				}
				finally
				{
					context.ExitScope();
				}
			}

			return context.Offset += tDataLen;
		}


		public long RawLength
		{
			get
			{
				if (value != null && value.Length > 0)
				{
					return value.Length + sizeof(uint);
				}
				else
				{
					return 0;
				}
			}
		}
	}
}