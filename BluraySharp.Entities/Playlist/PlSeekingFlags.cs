using System;
using BluraySharp.Architecture;

namespace BluraySharp.Playlist
{
	public class PlSeekingFlags : IBdPart
	{
		private byte value;

		public long SerializeTo(IBdRawIoContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawIoContext context)
		{
			value = context.DeserializeByte();

			return context.Offset;
		}

		public long RawLength
		{
			get
			{
				return sizeof(byte);
			}
		}
	}
}
