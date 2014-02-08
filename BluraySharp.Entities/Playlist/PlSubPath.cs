using System;
using System.Collections.Generic;
using BluraySharp.Common;
using BluraySharp.Architecture;

namespace BluraySharp.Playlist
{
	public class PlSubPath : BluraySharp.Playlist.IPlSubPath
	{
		public IList<IPlPlayItem> PlayItems
		{
			get { throw new NotImplementedException(); }
		}

		private Byte Reserved1 { get; set; }
		private Byte Reserved2 { get; set; }

		public PlSubPathType Type { get; set; }

		private BdBitwise16 repeatOption = new BdBitwise16();

		public IList<PlSubPlayItem> PlayItemsX { get; private set; }

		public IPlPlayItem CreateSubPlayItem()
		{
			return new PlSubPlayItem();
		}

		public long SerializeTo(IBdRawIoContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawIoContext context)
		{
			uint tDataLen;

			tDataLen = context.DeserializeUInt32();
			context.EnterScope(tDataLen);

			try
			{
				Reserved1 = context.DeserializeByte();
				Type = (PlSubPathType) context.DeserializeByte();

				repeatOption = context.Deserialize<BdBitwise16>();
				Reserved2 = context.DeserializeByte();

				byte tSubPlayItemCount = context.DeserializeByte();
				PlayItemsX.Clear();

				for (byte i = 0; i < tSubPlayItemCount; ++i)
				{
					PlayItemsX.Add(context.Deserialize<PlSubPlayItem>());
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
			get
			{
				long tDataLen = sizeof(uint);
				tDataLen += sizeof(byte) * 3;
				tDataLen += repeatOption.RawLength;

				foreach (IBdPart tObj in this.PlayItemsX)
				{
					tDataLen += tObj.RawLength;
				}

				return tDataLen;
			}
		}

		public PlSubPath()
		{
			PlayItemsX = new List<PlSubPlayItem>();
		}
	}
}
