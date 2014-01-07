using System;

namespace BluraySharp.Playlist
{
	public class PlStnRecordCodecInfo : BluraySharp.Playlist.IPlStnRecordCodecInfo
	{
		public long SerializeTo(IBdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawSerializeContext context)
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
