using System;

namespace BluraySharp.Common
{
	public class BdTime: IBdRawSerializable
	{
		public override string ToString()
		{
			return this.AsSpan.ToString();
		}

		public TimeSpan AsSpan
		{
			get
			{
				return new TimeSpan(_Value * 200L / 9);
			}
			set
			{
				_Value = (uint) (value.Ticks * 9 / 200);
			}
		}

		private uint _Value = 0;

		public long SerializeTo(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(BdRawSerializeContext context)
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
	}
}
