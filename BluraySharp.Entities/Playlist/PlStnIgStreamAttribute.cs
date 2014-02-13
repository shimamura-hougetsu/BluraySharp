using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Architecture;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlStnIgStreamAttribute : IBdPart
	{
		internal BdIgCodingType CodingType { get; set; }

		internal BdLang Language { get; set; }

		internal byte[] ReservedForFutureUse { get; set; }

		public long SerializeTo(IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			byte tFieldLen = context.DeserializeByte();
			context.EnterScope(tFieldLen);
			try
			{
				this.CodingType = (BdIgCodingType)context.DeserializeByte();

				string tLangCode = context.DeserializeString(3);
				this.Language = BdLangCode.ValueOf(tLangCode);

				this.ReservedForFutureUse = context.DeserializeBytes(1);
			}
			finally
			{
				context.ExitScope();
			}

			return context.Position;
		}

		public long RawLength
		{
			get {
				return sizeof(byte) + sizeof(byte) * 3 + sizeof(byte);
			}
		}
	}
}
