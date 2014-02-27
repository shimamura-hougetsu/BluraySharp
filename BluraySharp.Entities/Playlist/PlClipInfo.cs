﻿using System;
using BluraySharp.Architecture;
using System.Text;

namespace BluraySharp.PlayList
{
	public class PlClipInfo : IPClipInfo
	{
		private string clipCodec = "M2TS";

		private const int clipCodecStringLen = 4;
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

		private const int clipIdStringLen = 5;
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
			//-string tIdString = context.DeserializeString(clipIdStringLen, Encoding.UTF8);
			//-uint tId = uint.Parse(tIdString);

			//-if (tId < 0 || tId > 99999u)
			{
				//Invalid ClipId
				throw new ArgumentException("value");
			}

			//-this.ClipId = tId;
			//-this.ClipCodec = context.DeserializeString(clipCodecStringLen, Encoding.UTF8);

			return context.Position;
		}

		public long RawLength
		{
			get
			{
				return clipIdStringLen + clipCodecStringLen;
			}
		}

		public override string ToString()
		{
			return ClipId + ClipCodec;
		}
	}
}