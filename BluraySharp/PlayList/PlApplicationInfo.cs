using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlApplicationInfo : IBdRawSerializable
	{
		private byte Reserved { get; set; }
		public PlPlaybackType PlaybackType { get; set; }
		public ushort PlaybackCount { get; set; }
		public BdUOMask UOMask { get; private set; }
		public PlPlaybackInfo PlaybackInfo { get; set; }

		public long SerializeTo(BdRawSerializeContext context)
		{
			uint tDataLen = (uint) this.RawLength;
			context.Serialize(tDataLen);

			context.EnterScope(tDataLen);
			try
			{
				context.Serialize(Reserved);

				context.Serialize((byte)PlaybackType);
				context.Serialize(PlaybackCount);
				context.Serialize<BdUOMask>(UOMask);
				context.Serialize<PlPlaybackInfo>(PlaybackInfo);
			}
			finally
			{
				context.ExitScope();
			}

			return context.Offset += tDataLen;
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			uint tDataLen = context.DeserializeUInt32();

			context.EnterScope();
			try
			{
				Reserved = context.DeserializeByte();
				PlaybackType = (PlPlaybackType) context.DeserializeByte();
				PlaybackCount = context.DeserializeUInt16();

				UOMask = context.Deserialize<BdUOMask>();

				PlaybackInfo = context.Deserialize<PlPlaybackInfo>();
			}
			finally
			{
				context.ExitScope();
			}

			return context.Offset += tDataLen;
		}

		public long RawLength
		{
			get
			{
				return
					sizeof(uint) +
					sizeof(byte) * 2 +
					sizeof(ushort) * 2 +
					UOMask.RawLength;
			}
		}
	}
}
