using System;
using System.Xml.Serialization;
using BluraySharp.Architecture;
using BluraySharp.Common;
using System.Text;

namespace BluraySharp.PlayList
{
	public class PlayList : BluraySharp.PlayList.IPlayList
	{
		public string MplsMark { get; internal set; }

		public string MplsVer { get; set; }

		public IPlAppInfo ApplicationInfo { get; internal set; }

		public IPlPlayItemList PlayItemList { get; internal set; }

		public IPlMarkList MarkList { get; internal set; }

		public BdExtensionData ExtensionData { get; set; }

		internal byte[] ReservedForFutureUse { get; set; }
		
		#region IBdSerializable
		public long SerializeTo(IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			//-this.MplsMark = context.DeserializeString(4, Encoding.UTF8);
			//-this.MplsVer = context.DeserializeString(4, Encoding.UTF8);

			//-uint tOffsetPlayItemList = context.DeserializeUInt32();
			//-uint tOffsetMarkList = context.DeserializeUInt32();
			//-uint tOffsetExtDatList = context.DeserializeUInt32();

			//-this.ReservedForFutureUse = context.Deserialize(20);

			//-this.ApplicationInfo = context.Deserialize<PlAppInfo>();

			//Padding words here, 2*N totally

			//-if (tOffsetPlayItemList != 0)
			{
				//-	context.Position = tOffsetPlayItemList;
				this.PlayItemList = context.Deserialize<PlPlayItemList>();
			}

			//Padding words here, 2*N totally

			//-if (tOffsetMarkList != 0)
			{
				//-	context.Position = tOffsetMarkList;
				this.MarkList = context.Deserialize<PlMarkList>();
			}

			//Padding words here, 2*N totally

			//-if (tOffsetExtDatList != 0)
			{
				//-	context.Position = tOffsetExtDatList;
				this.ExtensionData = context.Deserialize<BdExtensionData>();
			}

			//Padding words here, 2*N totally

			return context.Position;
		}

		public long RawLength
		{
			get
			{
				return
					MplsMark.Length + MplsVer.Length + //MPLS Mark + Ver
					sizeof(uint) * 3 + //Offsets of lists
					ReservedForFutureUse.Length + //Reserved
					ApplicationInfo.GetRawLength() +
					PlayItemList.GetRawLength() +
					MarkList.GetRawLength() +
					ExtensionData.GetRawLength();
			}
		}

		public PlayList()
		{
			MplsMark = "MPLS";
			MplsVer = "0200";
			ApplicationInfo = new PlAppInfo();
			PlayItemList = new PlPlayItemList();
			MarkList = new PlMarkList();
			ExtensionData = null;

			ReservedForFutureUse = null;
		}
		#endregion IBdSerializable

	}
}
