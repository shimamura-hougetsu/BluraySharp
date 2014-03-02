using System.Collections.Generic;
using System.Text;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdStringFieldAttribute : BdFieldAttribute
	{
		public int ByteCount { get; private set; }
		public Encoding Encoding { get; private set; }

		public BdStringFieldAttribute(int byteCount, BdCharacterCodingType encoding)
			: base(BdFieldType.String)
		{
			this.ByteCount = byteCount;
			this.Encoding = BdStringFieldAttribute.encodings[encoding];
		}

		public static Dictionary<BdCharacterCodingType, Encoding> encodings =
			new Dictionary<BdCharacterCodingType, Encoding>()
			{
				{BdCharacterCodingType.UTF8, Encoding.UTF8},
				{BdCharacterCodingType.UTF16BE, Encoding.BigEndianUnicode},
				{BdCharacterCodingType.Unknown, Encoding.UTF8}
			};
	}
}
