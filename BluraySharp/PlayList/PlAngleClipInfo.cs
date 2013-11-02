using System;

namespace BluraySharp.PlayList
{
	public class PlAngleClipInfo : IBdRawSerializable
	{
		private string _ClipCodec = "M2TS";

		public string ClipCodec {
			get
			{
				return _ClipCodec;
			}
			set
			{
				if (!value.ToUpper().Equals(_ClipCodec))
				{
					throw new ArgumentException("value");
				}
			}
		}

		private uint _ClipId = 0;
		public string ClipId
		{
			get
			{
				return _ClipId.ToString("D5");
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

				_ClipId = tId;
			}
		}

		public long SerializeTo(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			this.ClipId = context.DeserializeString(5);
			this.ClipCodec = context.DeserializeString(4);

			return context.Offset;
		}

		public long RawLength
		{
			get
			{
				return ClipId.Length + ClipCodec.Length;
			}
		}
	}
}
