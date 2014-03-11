﻿using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BluraySharp.PlayList
{
	[BdPartScope(BdIntSize.U8)]
	internal class PlStnCodecInfoRoot : BdPart
	{
		public PlStnCodecInfoRoot(byte codecType)
		{
			this.CodecType = codecType;
		}

		private byte codecType;
		private IPlStnCodecInfo codecInfo;

		[BdUIntField(BdIntSize.U8)]
		public byte CodecType
		{
			get { return this.codecType; }
			set
			{
				if (this.codecType != value)
				{
					this.UpdateCodecInfoType(value);
				}
			}
		}

		[BdSubPartField]
		public IPlStnCodecInfo CodecInfo
		{
			get { return this.codecInfo; }
		}

		public override string ToString()
		{
			return "Internal StnCodecInfo Serializing Helper";
		}

		private delegate IPlStnCodecInfo CodecInfoCreator();
		private static readonly Dictionary<string, CodecInfoCreator> bdStreamCodingTypeCatagory =
			new Dictionary<string, CodecInfoCreator>()
			{ 
				{"Vi", () => new PlStnViCodecInfo() },
				{"Au", () => new PlStnAuCodecInfo() },
				{"Ig", () => new PlStnIgCodecInfo() },
				{"Pg", () => new PlStnPgCodecInfo() },
				{"Ts", () => new PlStnTsCodecInfo() },
				{"Sa", () => new PlStnAuCodecInfo() }
			};
		private static readonly Type[] bdStreamCodingTypes =
			new Type[]
		{
			typeof(BdViCodingType),
			typeof(BdAuCodingType),
			typeof(BdStCodingType),
			typeof(BdIgCodingType),
			typeof(BdSaCodingType)
		};

		private void UpdateCodecInfoType(byte value)
		{
			if (value == 0)
			{
				throw new ArgumentException("value");
			}

			Type tValueType = PlStnCodecInfoRoot.bdStreamCodingTypes.First(
				xType => Enum.IsDefined(xType, value));

			if (tValueType.IsNull())
			{
				throw new ArgumentException("value");
			}

			string tValuePrefix = Enum.GetName(tValueType, value).Substring(0, 2);

			if (!PlStnCodecInfoRoot.bdStreamCodingTypeCatagory.ContainsKey(tValuePrefix))
			{
				throw new ArgumentException("value");
			}

			CodecInfoCreator tCodecInfoCreator = 
				PlStnCodecInfoRoot.bdStreamCodingTypeCatagory[tValuePrefix];

			if (tCodecInfoCreator.IsNull())
			{
				throw new ArgumentException("value");
			}

			this.codecInfo = tCodecInfoCreator();
			this.codecType = value;
		}
	}
}