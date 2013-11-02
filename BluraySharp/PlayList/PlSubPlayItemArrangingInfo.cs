using System;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlSubPlayItemArrangingInfo : IBdRawSerializable, BluraySharp.PlayList.IPlArrangingInfo
	{
		private uint _Value = 1;

		public bool IsMultiAngle { get; set; }

		public BdConnectionCondition ConnectionCondition { get; set; }

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
