using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibElfin.WinApi;
using LibElfin.WinApi.MemoryBlock;

namespace BluraySharp.PlayList
{
	public class PlayList : IBdRawSerializable
	{
		public PlayList()
		{
			this.MplsMark = "MPLS";
			this.MplsVer = "0200";
			this.PlayListInfo = new PlayListInfo();
			
			this.PlayItemList = new PlayItemList();
			this.MarkList = new MarkList();
			this.ExtDatList = new ExtDatList();
		}

		public string MplsMark { get; private set; }
		public string MplsVer { get; private set; }

		private byte[] Reserved { get; set; }
		public PlayListInfo PlayListInfo { get; private set; }

		public PlayItemList PlayItemList { get; private set; }
		public MarkList MarkList { get; private set; }
		public ExtDatList ExtDatList  { get; private set; }

		public long SerializeTo(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			this.MplsMark = context.DeserializeString(4);

			this.MplsVer = context.DeserializeString(4);

			uint tOffsetPlayItemList = context.DeserializeUInt32();
			uint tOffsetMarkList = context.DeserializeUInt32();
			uint tOffsetExtDatList = context.DeserializeUInt32();

			this.Reserved = context.DeserializeBytes(20);

			this.PlayListInfo = context.Deserialize<PlayListInfo>();

			if (tOffsetPlayItemList != 0)
			{
				context.Offset = tOffsetPlayItemList;
				this.PlayItemList = context.Deserialize<PlayItemList>();
			}

			if (tOffsetMarkList != 0)
			{
				context.Offset = tOffsetMarkList;
				this.MarkList = context.Deserialize<MarkList>();
			}

			if (tOffsetExtDatList != 0)
			{
				context.Offset = tOffsetExtDatList;
				this.ExtDatList = context.Deserialize<ExtDatList>();
			}

			return context.Offset;
		}

		public long Length
		{
			get {
				return
					8 + //MPLS Mark + Ver
					12 + //Offsets of lists
					Reserved.Length + //Reserved
					PlayListInfo.Length +
					PlayItemList.Length +
					MarkList.Length +
					ExtDatList.Length;
			}
		}
	}
}
