using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlSubPlayItem : IPlayItem, IBdRawSerializable
	{
		public byte StcId { get; set; }
		public BdTime InTime { get; set; }
		public BdTime OutTime { get; set; }

		public ushort SyncPlayItemId { get; set; }
		public BdTime SyncPlayTimeOffset { get; set; }

		public IPlArrangingInfo ArrangingInfo { get; set; }

		public IList<IPlClipInfo> AngleList { get; private set; }

		public void AddAngle(string codec, string id)
		{
			PlAngleClipInfo tAngle = new PlAngleClipInfo() { ClipCodec = codec, ClipId = id };
			AngleList.Add(tAngle);
		}

		public long SerializeTo(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			ushort tDataLen;

			tDataLen = context.DeserializeUInt16();
			context.EnterScope(tDataLen);

			try
			{
				string tClipId = context.DeserializeString(5);
				string tClipCodec = context.DeserializeString(4);
				this.AddAngle(tClipCodec, tClipId);

				ArrangingInfo = context.Deserialize<PlArrangingInfo>();
				StcId = context.DeserializeByte();

				InTime = context.Deserialize<BdTime>();
				OutTime = context.Deserialize<BdTime>();

				SyncPlayItemId = context.DeserializeUInt16();
				SyncPlayTimeOffset = context.Deserialize<BdTime>();

				if (ArrangingInfo.IsMultiAngle)
				{
					byte tAngleCount = context.DeserializeByte();
					if (tAngleCount < 1)
					{
						tAngleCount = 1;
					}

					for (byte i = 1; i < tAngleCount; ++i)
					{
						AngleList.Add(context.Deserialize<PlAngleClipInfo>());
					}
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

		public PlSubPlayItem()
		{
			this.AngleList = new List<IPlClipInfo>();
		}
	}
}
