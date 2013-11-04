﻿using System;

namespace BluraySharp.Common
{
	public struct BdTime: IBdRawSerializable
	{
		private uint _Value;

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

		public override string ToString()
		{
			return this.AsSpan.ToString();
		}
	}
}
