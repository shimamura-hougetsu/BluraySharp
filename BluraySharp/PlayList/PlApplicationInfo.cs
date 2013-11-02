using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlApplicationInfo : IBdRawSerializable
	{
		private byte Reserved { get; set; }
		public byte PlayBackType { get; set; }
		public ushort PlayBackCount { get; set; }
		public BdUOMask UOMask { get; private set; }
		public ushort PlayBackFlags { get; set; } //TODO: define a class

		public long SerializeTo(BdRawSerializeContext context)
		{
			uint tDataLen = (uint) this.RawLength;
			context.Serialize(tDataLen);

			context.EnterScope(tDataLen);
			try
			{
				context.Serialize(Reserved);

				context.Serialize(PlayBackType);
				context.Serialize(PlayBackCount);
				context.Serialize<BdUOMask>(UOMask);
				context.Serialize(PlayBackFlags);
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
				PlayBackType = context.DeserializeByte();
				PlayBackCount = context.DeserializeUInt16();

				UOMask = context.Deserialize<BdUOMask>();

				PlayBackFlags = context.DeserializeUInt16();
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
