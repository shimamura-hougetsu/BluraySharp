using System;
using BluraySharp.Common.Serializing;


namespace BluraySharp.Common
{
	public class BdTime: IBdPart
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

		public uint AsFrameCount(BdViFrameRate frameRate)
		{
			throw new NotImplementedException();
		}

		public long SerializeTo(IBdRawWriteContext context)
		{
			//-context.Serialize(this.value);

			return context.Position;
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			//-this.value = context.DeserializeUInt32();

			return context.Position;
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
