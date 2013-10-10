using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class PlaybackStillInfo: IBdRawSerializable
	{
		private byte _ModeValue;
		private ushort _TimeValue;

		public long SerializeTo(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			_ModeValue = context.DeserializeByte();
			_TimeValue = context.DeserializeUInt16();

			return context.Offset;
		}

		public long Length
		{
			get { throw new NotImplementedException(); }
		}
	}
}
