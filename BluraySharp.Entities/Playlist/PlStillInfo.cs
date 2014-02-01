using System;

namespace BluraySharp.Playlist
{
	public class PlStillInfo : IBdObject
	{
		private byte modeValue;
		private ushort timeValue;

		public long SerializeTo(IBdRawIoContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawIoContext context)
		{
			modeValue = context.DeserializeByte();
			timeValue = context.DeserializeUInt16();

			return context.Offset;
		}

		public long RawLength
		{
			get
			{
				return sizeof(byte) + sizeof(ushort);
			}
		}
	}
}
