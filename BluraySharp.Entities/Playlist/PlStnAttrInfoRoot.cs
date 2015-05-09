/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at BitBucket (https://bitbucket.org/subelf/bluraysharp)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/

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
		public PlStnAttrInfoRoot(BdStreamCodingType attrType)
		{
			this.UpdateAttrInfoType(attrType);
		}

		#region AttrInfoType

		private BdStreamCodingType attrInfoType;

		[BdUIntField(BdIntSize.U8)]
		public BdStreamCodingType AttrInfoType
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
		
		private void UpdateAttrInfoType(BdStreamCodingType value)
		{
			Type tValueType = typeof(BdStreamCodingType);

			if (value == BdStreamCodingType.Unknown || !tValueType.IsEnumDefined(value))
			{
				//TODO: Invalid info type value;
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
