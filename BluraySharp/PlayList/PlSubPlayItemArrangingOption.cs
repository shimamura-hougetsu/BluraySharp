using System;
using BluraySharp.Common;

namespace BluraySharp.Playlist
{
	public class PlSubPlayItemArrangingOption : IBdRawSerializable, IPlArrangingOption
	{
		private uint _Value = 1;

		public bool IsMultiAngle
		{
			get
			{
				return _Value.GetBits(0, 1) == 1;
			}
			set
			{
				_Value = _Value.SetBits(0, 1, (uint)(value ? 1u : 0u));
			}
		}

		public BdConnectionCondition ConnectionCondition
		{
			get
			{
				return (BdConnectionCondition)_Value.GetBits(1, 4);
			}
			set
			{
				_Value = _Value.SetBits(1, 4, (uint)value);
			}
		}

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
