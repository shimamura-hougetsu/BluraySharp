using System;

namespace BluraySharp.Playlist
{
	public class PlStillInfo : IBdRawSerializable
	{
		private byte _ModeValue;
		private ushort _TimeValue;

		public long SerializeTo(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			_ModeValue = context.DeserializeByte();
			_TimeValue = context.DeserializeUInt16();

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
