using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Architecture;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlStnPgStreamAttributeFields : PlStnStStreamAttributeFields, IPlStnPgStreamAttribute
	{
		public BdLang Language { get; set; }
		internal byte[] ReservedForFutureUse { get; set; }

		public PlStnPgStreamAttributeFields()
			: base(BdStCodingType.Pg)
		{
			ReservedForFutureUse = new byte[1];
		}

		public override long SerializeTo(IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public override long DeserializeFrom(IBdRawReadContext context)
		{
			string tLangCode = context.DeserializeString(3);
			this.Language = BdLangCode.ValueOf(tLangCode);

			this.ReservedForFutureUse = context.DeserializeBytes(1);

			return context.Position;
		}

		public override long RawLength
		{
			get
			{
				return sizeof(byte) * 3 + sizeof(byte) * 1;
			}
		}
	}
}
