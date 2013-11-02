using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class PlSubPath : IBdRawSerializable
	{
		private Byte Reserved1 { get; set; }
		private Byte Reserved2 { get; set; }

		public PlSubPathType Type { get; set; }

		public PlSubPathRepeatInfo RepeatInfo { get; set; }

		public IList<PlSubPlayItem> PlayItems { get; private set; }

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
				Type = (PlSubPathType) context.DeserializeByte();

				RepeatInfo = context.Deserialize<PlSubPathRepeatInfo>();
				Reserved2 = context.DeserializeByte();

				byte tSubPlayItemCount = context.DeserializeByte();
				PlayItems.Clear();

				for (byte i = 0; i < tSubPlayItemCount; ++i)
				{
					PlayItems.Add(context.Deserialize<PlSubPlayItem>());
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

		public PlSubPath()
		{
			PlayItems = new List<PlSubPlayItem>();
		}
	}
}
