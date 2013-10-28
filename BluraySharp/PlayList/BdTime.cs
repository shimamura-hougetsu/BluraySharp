using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class BdTime: IBdRawSerializable
	{
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

		public long Length
		{
			get
			{
				return sizeof(uint);
			}
		}
	}
}
