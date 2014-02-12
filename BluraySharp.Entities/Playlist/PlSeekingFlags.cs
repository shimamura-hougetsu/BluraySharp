using System;
using BluraySharp.Architecture;

namespace BluraySharp.Playlist
{
	public class PlSeekingFlags : IBdPart
	{
		private byte value;

		public long SerializeTo(IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			value = context.DeserializeByte();

			return context.Position;
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
