using System;

namespace BluraySharp.Common
{
	public struct BdTime: IBdObject
	{
		private uint value;

		public TimeSpan AsSpan
		{
			get
			{
				return new TimeSpan(value * 2000L / 9);
			}
			set
			{
				this.value = (uint) (value.Ticks * 9 / 2000);
			}
		}

		public uint AsFrameCount(BdStreamInfo streamInfo)
		{
			throw new NotImplementedException();
		}

		public long SerializeTo(IBdRawIoContext context)
		{
			context.Serialize(this.value);

			return context.Offset;
		}

		public long DeserializeFrom(IBdRawIoContext context)
		{
			this.value = context.DeserializeUInt32();

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
