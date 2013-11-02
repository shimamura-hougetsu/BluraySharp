using System;
using BluraySharp.Common;

namespace BluraySharp.Playlist
{
	public class PlayList : IBdRawSerializable
	{
		public string MplsMark { get; private set; }
		public string MplsVer { get; private set; }

		private byte[] Reserved { get; set; }
		public PlApplicationInfo ApplicationInfo { get; private set; }

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

			this.ApplicationInfo = context.Deserialize<PlApplicationInfo>();

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
					MplsMark.Length + MplsVer.Length + //MPLS Mark + Ver
					sizeof(uint) * 3 + //Offsets of lists
					Reserved.Length + //Reserved
					ApplicationInfo.RawLength +
					PlayItemList.RawLength +
					MarkList.RawLength +
					ExtensionData.RawLength;
			}
		}

		public PlayList()
		{
			this.MplsMark = "MPLS";
			this.MplsVer = "0200";
			this.ApplicationInfo = new PlApplicationInfo();

			this.PlayItemList = new PlPlayItemList();
			this.MarkList = new PlMarkList();
			this.ExtensionData = new BdExtensionData();
		}
	}
}
