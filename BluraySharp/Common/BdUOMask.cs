using System.Text;
using System;
namespace BluraySharp.Common
{
	public struct BdUOMask : IBdRawSerializable
	{
		private BdBitwise64 _Value;

		public bool this[BdUOFlag index]
		{
			get
			{
				return _Value[(byte)index, 1] == 1;
			}
			set
			{
				_Value[(byte)index, 1] = (value ? 1u : 0u);
			}
		}

		public long SerializeTo(BdRawSerializeContext context)
		{
			context.Serialize(_Value);

			return context.Offset;
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			_Value = context.Deserialize<BdBitwise64>();

			return context.Offset;
		}

		public long RawLength
		{
			get
			{
				return _Value.RawLength;
			}
		}
	}
}
