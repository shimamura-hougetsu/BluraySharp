using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class PlaybackArrangingFlags : IBdRawSerializable
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

		public long Length
		{
			get
			{
				return sizeof(ushort);
			}
		}
	}
}
