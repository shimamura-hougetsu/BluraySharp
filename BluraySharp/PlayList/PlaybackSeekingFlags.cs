using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class PlaybackSeekingFlags : IBdRawSerializable
	{
		private byte _Value;

		public long SerializeTo(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			_Value = context.DeserializeByte();

			return context.Offset;
		}

		public long RawLength
		{
			get { throw new NotImplementedException(); }
		}
	}
}
