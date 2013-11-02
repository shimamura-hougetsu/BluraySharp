using System;

namespace BluraySharp.Playlist
{
	public class PlSeekingFlags : IBdRawSerializable
	{
		private byte _Value;

		public long SerializeTo(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			_Value = context.DeserializeByte();

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
