namespace BluraySharp.Common
{
	public class BdUOMask : IBdRawSerializable
	{
		private ulong _Value = 0;

		public bool this[BdUOFlag index]
		{
			get
			{
				return ((_Value >> (byte)index) & 0x01) == 1;
			}
			set
			{
				ulong tMask = ((value ? 1UL : 0UL) << (byte)index);

				if (value)
				{
					_Value |= tMask;
				}
				else
				{
					_Value &= tMask;
				}
			}
		}

		public long SerializeTo(BdRawSerializeContext context)
		{
			context.Serialize(_Value);

			return context.Offset;
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			_Value = context.DeserializeUInt64();

			return context.Offset;
		}

		public long RawLength
		{
			get
			{
				return sizeof(ulong);
			}
		}
	}
}
