using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class PlaybackAngle : IClipReferance, IBdRawSerializable
	{
		public string ClipCodec { get; set; }
		public string ClipId { get; set; }

		public long SerializeTo(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long RawLength
		{
			get { throw new NotImplementedException(); }
		}
	}
}
