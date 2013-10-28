using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class PlaybackAngle : IBdRawSerializable
	{
		public long SerializeTo(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long Length
		{
			get { throw new NotImplementedException(); }
		}
	}
}
