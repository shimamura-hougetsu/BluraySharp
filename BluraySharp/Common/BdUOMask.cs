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
				return _Value.GetBit((byte)index);
			}
			set
			{
				_Value = value ? _Value.SetBit((byte)index) : _Value.UnsetBit((byte) index);
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
