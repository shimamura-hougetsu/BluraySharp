using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Architecture;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlStnStStreamAttribute : IBdPart
	{
		internal BdStCodingType CodingType
		{
			get
			{
				return (this.Fields != null) ? this.Fields.CodingType : BdStCodingType.Unknown;
			}
			set
			{
				switch (value)
				{
					case BdStCodingType.Pg:
						this.Fields = new PlStnPgStreamAttributeFields();
						break;
					case BdStCodingType.Ts:
						this.Fields = new PlStnTsStreamAttributeFields();
						break;
					case BdStCodingType.Unknown:
						this.Fields = null;
						break;
				}
			}
		}

		internal PlStnStStreamAttributeFields Fields { get; private set; }

		
		public virtual long SerializeTo(IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public virtual long DeserializeFrom(IBdRawReadContext context)
		{
			byte tFieldLen = context.DeserializeByte();
			context.EnterScope(tFieldLen);
			try
			{
				this.CodingType = (BdStCodingType)context.DeserializeByte();
				if (this.Fields != null)
				{
					context.Deserialize(this.Fields);
				}
			}
			finally
			{
				context.ExitScope();
			}

			return context.Position;
		}

		public virtual long RawLength
		{
			get
			{
				return sizeof(byte) * 3;
			}
		}
	}
}
