using System;
using BluraySharp.Architecture;

namespace BluraySharp.Playlist
{
	public class PlStnRecord : BluraySharp.Playlist.IPlStnRecord
	{
		public IPlStnRecordCodecInfo CodecInfo
		{
			get { throw new NotImplementedException(); }
		}

		public IPlStnRecordStreamInfo StreamInfo
		{
			get { throw new NotImplementedException(); }
		}

		private PlStnRecordStreamInfo streamInfo;
		private PlStnRecordCodecInfo codecInfo;

		public long SerializeTo(IBdRawIoContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawIoContext context)
		{
			streamInfo = context.Deserialize<PlStnRecordStreamInfo>();
			codecInfo = context.Deserialize<PlStnRecordCodecInfo>();

			return context.Offset;
		}

		public long RawLength
		{
			get
			{
				return streamInfo.RawLength + codecInfo.RawLength;
			}
		}
	}
}
