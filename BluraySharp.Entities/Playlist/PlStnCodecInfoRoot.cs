using BluraySharp.Common;
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
			this.UpdateCodecInfoType(codecType);
		}

		#region CodecInfoType

		private byte codecInfoType;

		[BdUIntField(BdIntSize.U8)]
		public byte CodecInfoType
		{
			get { return this.codecInfoType; }
			set
			{
				if (this.codecInfoType != value)
				{
					this.UpdateCodecInfoType(value);
				}
			}
		}

		private delegate IPlStnCodecInfo CodecInfoCreator();
		private static readonly Dictionary<string, CodecInfoCreator> bdStreamCodingTypeCatagory =
			new Dictionary<string, CodecInfoCreator>()
			{ 
				{"Vi", () => new PlStnViCodecInfo() },
				{"Au", () => new PlStnAuCodecInfo() },
				{"Gx", () => new PlStnGxCodecInfo() },
				{"Tx", () => new PlStnTxCodecInfo() },
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
				//Invalid info type value;
				throw new ArgumentException("value");
			}

			Type tValueType = PlStnCodecInfoRoot.bdStreamCodingTypes.First(
				xType => PlStnCodecInfoRoot.IsEnumDefined(xType, value));

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
			this.codecInfoType = value;
		}

		private static bool IsEnumDefined(Type enumType, byte value)
		{
			Type tEnumUnderlyingType = Enum.GetUnderlyingType(enumType);
			object tEnumValue = Convert.ChangeType(value, tEnumUnderlyingType);

			return Enum.IsDefined(enumType, tEnumValue);
		}

		#endregion

		#region CodecInfo

		private IPlStnCodecInfo codecInfo;

		[BdSubPartField]
		public IPlStnCodecInfo CodecInfo
		{
			get { return this.codecInfo; }
		}

		#endregion

		public override string ToString()
		{
			return "Internal StnCodecInfo Serializing Helper";
		}

	}
}
