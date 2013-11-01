using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class SubPath : IBdRawSerializable
	{
		private Byte Reserved1 { get; set; }
		private Byte Reserved2 { get; set; }

		public SubPathType Type { get; set; }

		public SubPathRepeatInfo RepeatInfo { get; set; }

		public IList<SubPlayItem> PlayItems { get; private set; }

		public long SerializeTo(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			uint tDataLen;

			tDataLen = context.DeserializeUInt32();
			context.EnterScope(tDataLen);

			try
			{
				Reserved1 = context.DeserializeByte();
				Type = (SubPathType) context.DeserializeByte();

				RepeatInfo = context.Deserialize<SubPathRepeatInfo>();
				Reserved2 = context.DeserializeByte();

				byte tSubPlayItemCount = context.DeserializeByte();
				PlayItems.Clear();

				for (byte i = 0; i < tSubPlayItemCount; ++i)
				{
					PlayItems.Add(context.Deserialize<SubPlayItem>());
				}
			}
			finally
			{
				context.ExitScope();
			}

			return context.Offset += tDataLen;
		}

		public long RawLength
		{
			get { throw new NotImplementedException(); }
		}

		public SubPath()
		{
			PlayItems = new List<SubPlayItem>();
		}
	}
}
