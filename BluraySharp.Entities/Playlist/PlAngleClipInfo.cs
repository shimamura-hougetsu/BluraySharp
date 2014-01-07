using System;

namespace BluraySharp.Playlist
{
	public class PlAngleClipInfo : BluraySharp.Playlist.IPlAngleClipInfo
	{
		private string clipCodec = "M2TS";

		public string ClipCodec {
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

		private uint clipFilename = 0;
		public string ClipFilename
		{
			get
			{
				return clipFilename.ToString("D5");
			}
			set
			{
				if(value == null)
				{
					throw new ArgumentNullException("value");
				}

				uint tId = uint.Parse(value);

				if (tId < 0 || tId > 99999u)
				{
					throw new ArgumentException("value");
				}

				clipFilename = tId;
			}
		}

		public long SerializeTo(IBdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawSerializeContext context)
		{
			this.ClipFilename = context.DeserializeString(5);
			this.ClipCodec = context.DeserializeString(4);

			return context.Offset;
		}

		public long RawLength
		{
			get
			{
				return ClipFilename.Length + ClipCodec.Length;
			}
		}

		public override string ToString()
		{
			return ClipFilename + ClipCodec;
		}
	}
}
