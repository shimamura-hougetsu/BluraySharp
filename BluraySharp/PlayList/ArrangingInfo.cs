using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class ArrangingInfo : IBdRawSerializable, BluraySharp.PlayList.IArrangingInfo
	{
		private uint _Value = 1;

		public bool IsMultiAngle
		{
			get;
			set;
		}

		public ConjunctionType ConjunctionType
		{
			get;
			set;
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
