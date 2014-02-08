using BluraySharp.Architecture;

namespace BluraySharp.Common
{
	public class BdStnRecordRef : IBdPart
	{
		private byte value;

		public long SerializeTo(IBdRawIoContext context)
		{
			context.Serialize(this.value);

			return context.Offset;
		}

		public long DeserializeFrom(IBdRawIoContext context)
		{
			this.value = context.DeserializeByte();

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
