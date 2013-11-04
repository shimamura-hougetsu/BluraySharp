using System.Text;
using System;
namespace BluraySharp.Common
{
	public struct BdUOMask : IBdRawSerializable
	{
		private ulong _Value;

		public bool this[BdUOFlag index]
		{
			get
			{
				return _Value.GetBits((byte)index, 1) == 1;
			}
			set
			{
				_Value = _Value.SetBits((byte)index, 1, value ? 1u : 0u);
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

		public override string ToString()
		{
			const int tLen = 72;
			StringBuilder tString = new StringBuilder(tLen, tLen);

			ulong tMask = _Value;
			
			for (sbyte i = 63; i >= 0; --i)
			{
				tString.Append((tMask & 0x8000000000000000u) == 0 ? '0' : '1');
				if ((i & 0x07) == 0)
				{
					tString.Append('-');
				}

				tMask <<= 1;
			}
			tString[tString.Length - 1] = '\0';

			return tString.ToString();
		}
	}
}
