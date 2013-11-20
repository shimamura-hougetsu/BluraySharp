using BluraySharp.Common;

namespace BluraySharp.Playlist
{
	public class PlApplicationInfo : IBdRawSerializable
	{
		private byte Reserved { get; set; }
		public PlPlaybackType PlaybackType { get; set; }
		public ushort PlaybackCount { get; set; }
		public BdUOMask UOMask { get; private set; }
		private BdBitwise16 _PlaybackOption = new BdBitwise16(0);

		public bool RandomAccess
		{
			get;
			set;
		}

		public bool AudioMix
		{
			get;
			set;
		}

		public bool BypassMixer
		{
			get;
			set;
		}

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
				context.Serialize<BdBitwise16>(_PlaybackOption);
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

				_PlaybackOption = context.Deserialize<BdBitwise16>();
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
