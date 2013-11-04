using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Playlist
{
	public class PlPlaybackOption : IBdRawSerializable
	{
		private ushort _Value = 0;

		public bool RandomAccess
		{
			get;
			set;
		}

		public bool AudioMix
		{
			get;
			set;
		}

		public bool BypassMixer
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
