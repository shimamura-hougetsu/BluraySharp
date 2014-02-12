using System;
using BluraySharp.Architecture;

namespace BluraySharp.Playlist
{
	public class PlAngleClipInfo : BluraySharp.Playlist.IPlAngleClipInfo
	{
		private string clipCodec = "M2TS";

		public string ClipCodec
		{
			get
			{
				return clipCodec;
			}
			set
			{
				if (!value.ToUpper().Equals(clipCodec))
				{
					throw new ArgumentException("value");
				}
			}
		}

		private uint clipId = 0;
		public uint ClipId
		{
			get
			{
				return this.clipId;
			}
			set
			{
				this.clipId = value;
			}
		}

		public long SerializeTo(IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			string tIdString = context.DeserializeString(5);
			uint tId = uint.Parse(tIdString);

			if (tId < 0 || tId > 99999u)
			{
				//Invalid ClipId
				throw new ArgumentException("value");
			}

			this.ClipId = tId;
			this.ClipCodec = context.DeserializeString(4);

			return context.Position;
		}

		public long RawLength
		{
			get
			{
				return sizeof(uint) + ClipCodec.Length;
			}
		}

		public override string ToString()
		{
			return ClipId + ClipCodec;
		}
	}
}
