using System.Text;
using System;
using BluraySharp.Architecture;

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

		public long SerializeTo(IBdRawWriteContext context)
		{
			context.Serialize(this.value);

			return context.Position;
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			this.value = new BdBitwise64();
			context.Deserialize(this.value);

			return context.Position;
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
