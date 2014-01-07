using System;

namespace BluraySharp.Common
{
	public struct BdTime: IBdRawSerializable
	{
		private uint _Value;

		public TimeSpan AsSpan
		{
			get
			{
				return new TimeSpan(_Value * 2000L / 9);
			}
			set
			{
				_Value = (uint) (value.Ticks * 9 / 2000);
			}
		}

		public long SerializeTo(IBdRawSerializeContext context)
		{
			context.Serialize(_Value);

			return context.Offset;
		}

		public long DeserializeFrom(IBdRawSerializeContext context)
		{
			_Value = context.DeserializeUInt32();

			return context.Offset;
		}

		public long RawLength
		{
			get
			{
				return sizeof(uint);
			}
		}

		public override string ToString()
		{
			return this.AsSpan.ToString();
		}
	}
}
