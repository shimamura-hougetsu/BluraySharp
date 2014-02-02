using System.Text;
using System;
namespace BluraySharp.Common
{
	public class BdUOMask : IBdPart
	{
		private BdBitwise64 value = new BdBitwise64();

		public bool this[BdUOFlag index]
		{
			get
			{
				return this.value[(byte)index, 1] == 1;
			}
			set
			{
				this.value[(byte)index, 1] = (value ? 1u : 0u);
			}
		}

		public long SerializeTo(IBdRawIoContext context)
		{
			context.Serialize(this.value);

			return context.Offset;
		}

		public long DeserializeFrom(IBdRawIoContext context)
		{
			this.value = context.Deserialize<BdBitwise64>();

			return context.Offset;
		}

		public long RawLength
		{
			get
			{
				return this.value.RawLength;
			}
		}
	}
}
