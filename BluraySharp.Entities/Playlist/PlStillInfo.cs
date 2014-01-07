using System;

namespace BluraySharp.Playlist
{
	public class PlStillInfo : IBdRawSerializable
	{
		private byte modeValue;
		private ushort timeValue;

		public long SerializeTo(IBdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawSerializeContext context)
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
