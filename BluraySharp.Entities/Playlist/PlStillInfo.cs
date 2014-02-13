using System;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public class PlStillInfo : IPlStillInfo
	{
		public PlStillMode StillMode { get; set; }
		public ushort StillDuration { get; set; }

		public long SerializeTo(IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			this.StillMode = (PlStillMode) context.DeserializeByte();
			this.StillDuration = context.DeserializeUInt16();

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
