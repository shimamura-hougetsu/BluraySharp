﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibElfin.WinApi;
using LibElfin.WinApi.MemoryBlock;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlayList : IBdRawSerializable
	{
		public PlayList()
		{
			this.MplsMark = "MPLS";
			this.MplsVer = "0200";
			this.PlayListInfo = new PlApplicationInfo();
			
			this.PlayItemList = new PlPlayItemList();
			this.MarkList = new PlMarkList();
			this.ExtensionData = new BdExtensionData();
		}

		public string MplsMark { get; private set; }
		public string MplsVer { get; private set; }

		private byte[] Reserved { get; set; }
		public PlApplicationInfo PlayListInfo { get; private set; }

		public PlPlayItemList PlayItemList { get; private set; }
		public PlMarkList MarkList { get; private set; }
		public BdExtensionData ExtensionData { get; private set; }

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

			this.PlayListInfo = context.Deserialize<PlApplicationInfo>();

			if (tOffsetPlayItemList != 0)
			{
				context.Offset = tOffsetPlayItemList;
				this.PlayItemList = context.Deserialize<PlPlayItemList>();
			}

			if (tOffsetMarkList != 0)
			{
				context.Offset = tOffsetMarkList;
				this.MarkList = context.Deserialize<PlMarkList>();
			}

			if (tOffsetExtDatList != 0)
			{
				context.Offset = tOffsetExtDatList;
				this.ExtensionData = context.Deserialize<BdExtensionData>();
			}

			return context.Offset;
		}

		public long RawLength
		{
			get {
				return
					8 + //MPLS Mark + Ver
					12 + //Offsets of lists
					Reserved.Length + //Reserved
					PlayListInfo.RawLength +
					PlayItemList.RawLength +
					MarkList.RawLength +
					ExtensionData.RawLength;
			}
		}
	}
}
