using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class StnRecord : IBdRawSerializable
	{
		public StnRecordStreamInfo StreamInfo { get; private set; }
		public StnRecordCodecInfo CodecInfo { get; private set; }

		public long SerializeTo(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			StreamInfo = context.Deserialize<StnRecordStreamInfo>();
			CodecInfo = context.Deserialize<StnRecordCodecInfo>();

			return context.Offset;
		}

		public long Length
		{
			get { throw new NotImplementedException(); }
		}
	}
}
