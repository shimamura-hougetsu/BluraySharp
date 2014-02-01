using System;
using BluraySharp.Common;
using System.Xml.Serialization;

namespace BluraySharp.Playlist
{
	[XmlRoot("MPLS")]
	public class PlayList : BluraySharp.Playlist.IPlayList
	{
		#region BluraySharp.Playlist.IPlayList

		[XmlIgnore]
		public string MplsMark
		{
			get
			{
				return MplsMarkX;
			}
		}

		[XmlIgnore]
		public string MplsVer
		{
			get
			{
				return MplsVerX;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}

				if (value.Length != 4)
				{
					throw new ArgumentException("value");
				}

				MplsVer = value;
			}
		}

		[XmlIgnore]
		public IPlAppInfo ApplicationInfo
		{
			get { return ApplicationInfoX; }
		}

		[XmlIgnore]
		public IPlPlayItemList PlayItemList
		{
			get { return PlayItemListX; }
		}

		[XmlIgnore]
		public IPlMarkList MarkList
		{
			get { return MarkListX; }
		}

		[XmlIgnore]
		public BdExtensionData ExtensionData
		{
			get { return ExtensionDataX; }
			set { ExtensionDataX = value; }
		}

		public IPlAppInfo CreateAppInfo()
		{
			return new PlAppInfo();
		}

		public IPlPlayItemList CreatePlayItemList()
		{
			return new PlPlayItemList();
		}

		public IPlMarkList CreateMarkList()
		{
			return new PlMarkList();
		}

		#endregion BluraySharp.Playlist.IPlayList

		#region Properties for XmlSerializing

		[XmlElement("type_indicator")]
		public string MplsMarkX { get; set; }

		[XmlElement("version_number")]
		public string MplsVerX { get; set; }

		[XmlElement("AppInfoPlayList")]
		public PlAppInfo ApplicationInfoX { get; set; }

		[XmlElement("PlayList")]
		public PlPlayItemList PlayItemListX { get; set; }

		[XmlElement("PlayListMark")]
		public PlMarkList MarkListX { get; set; }

		[XmlElement("ExtensionData")]
		public BdExtensionData ExtensionDataX { get; set; }

		private byte[] ReservedForFutureUse { get; set; }

		#endregion Properties for XmlSerializing

		#region IBdSerializable
		public long SerializeTo(IBdRawIoContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawIoContext context)
		{
			this.MplsMarkX = context.DeserializeString(4);
			this.MplsVerX = context.DeserializeString(4);

			uint tOffsetPlayItemList = context.DeserializeUInt32();
			uint tOffsetMarkList = context.DeserializeUInt32();
			uint tOffsetExtDatList = context.DeserializeUInt32();

			this.ReservedForFutureUse = context.DeserializeBytes(20);

			this.ApplicationInfoX = context.Deserialize<PlAppInfo>();

			//Padding words here, 2*N totally

			if (tOffsetPlayItemList != 0)
			{
				context.Offset = tOffsetPlayItemList;
				this.PlayItemListX = context.Deserialize<PlPlayItemList>();
			}

			//Padding words here, 2*N totally

			if (tOffsetMarkList != 0)
			{
				context.Offset = tOffsetMarkList;
				this.MarkListX = context.Deserialize<PlMarkList>();
			}

			//Padding words here, 2*N totally

			if (tOffsetExtDatList != 0)
			{
				context.Offset = tOffsetExtDatList;
				this.ExtensionDataX = context.Deserialize<BdExtensionData>();
			}

			//Padding words here, 2*N totally


			return context.Offset;
		}

		public long RawLength
		{
			get
			{
				return
					MplsMarkX.Length + MplsVerX.Length + //MPLS Mark + Ver
					sizeof(uint) * 3 + //Offsets of lists
					ReservedForFutureUse.Length + //Reserved
					ApplicationInfoX.GetRawLength() +
					PlayItemListX.GetRawLength() +
					MarkListX.GetRawLength() +
					ExtensionDataX.GetRawLength();
			}
		}

		public PlayList()
		{
			MplsMarkX = "MPLS";
			MplsVerX = "0200";
			ApplicationInfoX = new PlAppInfo();
			PlayItemListX = new PlPlayItemList();
			MarkListX = new PlMarkList();
			ExtensionDataX = null;

			ReservedForFutureUse = null;
		}
		#endregion IBdSerializable

	}
}
