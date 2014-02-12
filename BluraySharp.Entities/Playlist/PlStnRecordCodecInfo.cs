using System;
using BluraySharp.Architecture;

namespace BluraySharp.Playlist
{
	public class PlStnRecordCodecInfo : BluraySharp.Playlist.IPlStnRecordCodecInfo
	{
		public long SerializeTo(IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			byte tDataLen;
			tDataLen = context.DeserializeByte();

			return context.Position += tDataLen;
		}

		public long RawLength
		{
			get { throw new NotImplementedException(); }
		}
	}
}
