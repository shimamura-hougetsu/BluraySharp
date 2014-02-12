using BluraySharp.Architecture;

namespace BluraySharp.Common
{
	public class BdStnRecordRef : IBdPart
	{
		private byte value;

		public long SerializeTo(IBdRawWriteContext context)
		{
			context.Serialize(this.value);

			return context.Position;
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			this.value = context.DeserializeByte();

			return context.Position;
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
