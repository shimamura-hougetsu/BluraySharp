using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BluraySharp.PlayList
{
	[BdPartScope(BdIntSize.U8)]
	internal class PlStnAttrInfoRoot : BdPart
	{
		public PlStnAttrInfoRoot(byte attrType)
		{
			this.UpdateAttrInfoType(attrType);
		}

		#region AttrInfoType

		private byte attrInfoType;

		[BdUIntField(BdIntSize.U8)]
		public byte AttrInfoType
		{
			get { return this.attrInfoType; }
			set
			{
				if (this.attrInfoType != value)
				{
					this.UpdateAttrInfoType(value);
				}
			}
		}

		private delegate IPlStnAttrInfo AttrInfoCreator();
		private static readonly Dictionary<string, AttrInfoCreator> bdStreamCodingTypeCatagory =
			new Dictionary<string, AttrInfoCreator>()
			{ 
				{"Vi", () => new PlStnViAttrInfo() },
				{"Au", () => new PlStnAuAttrInfo() },
				{"Gx", () => new PlStnGxAttrInfo() },
				{"Tx", () => new PlStnTxAttrInfo() },
				{"Sa", () => new PlStnAuAttrInfo() }
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

		private void UpdateAttrInfoType(byte value)
		{
			if (value == 0)
			{
				//Invalid info type value;
				throw new ArgumentException("value");
			}

			Type tValueType = PlStnAttrInfoRoot.bdStreamCodingTypes.First(
				xType => PlStnAttrInfoRoot.IsEnumDefined(xType, value));

			if (tValueType.IsNull())
			{
				throw new ArgumentException("value");
			}

			string tValuePrefix = Enum.GetName(tValueType, value).Substring(0, 2);

			if (!PlStnAttrInfoRoot.bdStreamCodingTypeCatagory.ContainsKey(tValuePrefix))
			{
				throw new ArgumentException("value");
			}

			AttrInfoCreator tAttrInfoCreator =
				PlStnAttrInfoRoot.bdStreamCodingTypeCatagory[tValuePrefix];

			if (tAttrInfoCreator.IsNull())
			{
				throw new ArgumentException("value");
			}

			this.attrInfo = tAttrInfoCreator();
			this.attrInfoType = value;
		}

		private static bool IsEnumDefined(Type enumType, byte value)
		{
			Type tEnumUnderlyingType = Enum.GetUnderlyingType(enumType);
			object tEnumValue = Convert.ChangeType(value, tEnumUnderlyingType);

			return Enum.IsDefined(enumType, tEnumValue);
		}

		#endregion

		#region AttrInfo

		private IPlStnAttrInfo attrInfo;

		[BdSubPartField]
		public IPlStnAttrInfo AttrInfo
		{
			get { return this.attrInfo; }
		}

		#endregion

		public override string ToString()
		{
			return "Internal StnAttrInfo Serializing Helper";
		}

	}
}
