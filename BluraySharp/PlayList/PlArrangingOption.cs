using System;
using BluraySharp.Common;

namespace BluraySharp.Playlist
{
	public class PlArrangingOption : IPlArrangingOption
	{
		private ushort _Value = 1;

		public bool IsMultiAngle
		{
			get
			{
				return _Value.GetBits(4, 1) == 1;
			}
			set
			{
				_Value = _Value.SetBits(4, 1, (ushort)(value ? 1u : 0u));
			}
		}

		public BdConnectionCondition ConnectionCondition
		{
			get
			{
				return (BdConnectionCondition)_Value.GetBits(0, 4);
			}
			set
			{
				_Value = _Value.SetBits(0, 4, (ushort)value);
			}
		}

		public long SerializeTo(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			_Value = context.DeserializeUInt16();

			return context.Offset;
		}

		public long RawLength
		{
			get
			{
				return sizeof(ushort);
			}
		}
	}
}
