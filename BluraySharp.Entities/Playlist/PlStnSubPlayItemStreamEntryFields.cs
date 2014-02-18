using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class PlStnSubPlayItemStreamEntryFields : PlStnStreamEntryFields, IPlStnSubPlayItemStreamEntryFields
	{
		public byte SubPathId
		{
			get;
			set;
		}

		public byte SubClipEntryId
		{
			get;
			set;
		}

		public ushort StreamProgId
		{
			get;
			set;
		}

		public PlStnSubPlayItemStreamEntryFields()
			: base(PlStnStreamEntryType.SubPlayItem)
		{
		}

		private byte[] reservedForFutureUse = new byte[4];

		public override long SerializeTo(Architecture.IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public override long DeserializeFrom(Architecture.IBdRawReadContext context)
		{
			//-this.SubPathId = context.DeserializeByte();
			//-this.SubClipEntryId = context.DeserializeByte();
			//-this.StreamProgId = context.DeserializeUInt16();

			//-this.reservedForFutureUse = context.Deserialize(4);

			return context.Position;
		}

		public override long RawLength
		{
			get
			{
				return sizeof(byte) * 2 + sizeof(ushort) + sizeof(byte) * 4;
			}
		}
	}
}
