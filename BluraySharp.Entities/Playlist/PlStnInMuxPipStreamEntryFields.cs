using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class PlStnInMuxPipStreamEntryFields : PlStnStreamEntryFields, IPlStnInMuxPipStreamEntryFields
	{
		public byte SubPathId
		{
			get;
			set;
		}

		public ushort StreamProgId
		{
			get;
			set;
		}

		private byte[] reservedForFutureUse = new byte[5];

		public PlStnInMuxPipStreamEntryFields()
			: base(PlStnStreamEntryType.InMuxPip)
		{
		}

		public override long SerializeTo(Architecture.IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public override long DeserializeFrom(Architecture.IBdRawReadContext context)
		{
			//-this.StreamProgId = context.DeserializeByte();
			//-this.StreamProgId = context.DeserializeUInt16();

			//-this.reservedForFutureUse = context.Deserialize(5);

			return context.Position;
		}

		public override long RawLength
		{
			get
			{
				return sizeof(byte) + sizeof(ushort) + sizeof(byte) * 5;
			}
		}
	}
}
