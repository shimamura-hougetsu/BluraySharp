using System;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlArrangingInfo : IPlArrangingInfo
	{
		private ushort _Value = 1;

		public bool IsMultiAngle { get; set; }

		public BdConnectionCondition ConnectionCondition { get; set; }

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
