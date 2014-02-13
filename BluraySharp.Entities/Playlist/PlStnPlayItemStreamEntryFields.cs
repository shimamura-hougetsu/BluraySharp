using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class PlStnPlayItemStreamEntryFields : PlStnStreamEntryFields, IPlStnPlayItemStreamEntryFields
	{
		public ushort StreamProgId
		{
			get;
			set;
		}

		private byte[] reservedForFutureUse = new byte[6];

		public PlStnPlayItemStreamEntryFields()
			: base(PlStnStreamEntryType.PlayItem)
		{
		}

		public override long SerializeTo(Architecture.IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public override long DeserializeFrom(Architecture.IBdRawReadContext context)
		{
			this.StreamProgId = context.DeserializeUInt16();
			this.reservedForFutureUse = context.DeserializeBytes(6);

			return context.Position;
		}

		public override long RawLength
		{
			get
			{
				return sizeof(ushort) + sizeof(byte) * 6;
			}
		}
	}
}
