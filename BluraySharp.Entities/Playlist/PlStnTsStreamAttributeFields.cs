using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Architecture;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlStnTsStreamAttributeFields : PlStnStStreamAttributeFields, IPlStnTsStreamAttribute
	{
		public BdLang Language { get; set; }
		public BdCharacterCodingType CharCode { get; set; }

		internal byte[] ReservedForFutureUse { get; set; }

		public PlStnTsStreamAttributeFields()
			: base(BdStCodingType.Ts)
		{
		}

		public override long SerializeTo(IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public override long DeserializeFrom(IBdRawReadContext context)
		{
			this.CharCode = (BdCharacterCodingType)context.DeserializeByte();

			string tLangCode = context.DeserializeString(3, Encoding.UTF8);
			this.Language = BdLangCode.ValueOf(tLangCode);
				
			return context.Position;
		}

		public override long RawLength
		{
			get
			{
				return sizeof(byte) + sizeof(byte) * 3;
			}
		}

	}
}
