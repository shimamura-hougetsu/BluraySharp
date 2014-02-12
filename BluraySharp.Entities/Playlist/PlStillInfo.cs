using System;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public class PlStillInfo : IBdPart
	{
		private byte modeValue;
		private ushort timeValue;

		public long SerializeTo(IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			modeValue = context.DeserializeByte();
			timeValue = context.DeserializeUInt16();

			return context.Position;
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
