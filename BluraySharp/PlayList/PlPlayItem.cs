using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlPlayItem : IBdRawSerializable, IPlayItem
	{
		public byte StcId { get; set; }
		public BdTime InTime { get; set; }
		public BdTime OutTime { get; set; }

		public BdUOMask UOMask { get; private set; }
		public PlSeekingFlags SeekingFlags { get; private set; }

		public PlStillInfo StillInfo { get; private set; }

		public IPlArrangingInfo ArrangingInfo { get; private set; }

		public PlMultiAngleInfo MultiAngleInfo { get; private set; }

		public IList<IPlClipInfo> AngleList { get; private set; }
		public void AddAngle(string codec, string id)
		{
			PlAngleClipInfo tAngle = new PlAngleClipInfo() { ClipCodec = codec, ClipId = id };
			AngleList.Add(tAngle);
		}

		public PlStnTable StnTable
		{
			get;
			private set;
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
				UOMask = context.Deserialize<BdUOMask>();

				SeekingFlags = context.Deserialize<PlSeekingFlags>();
				StillInfo = context.Deserialize<PlStillInfo>();

				if (ArrangingInfo.IsMultiAngle)
				{
					byte tAngleCount = context.DeserializeByte();

					MultiAngleInfo = context.Deserialize<PlMultiAngleInfo>();

					if (tAngleCount < 1)
					{
						tAngleCount = 1;
					}

					for(byte i = 0; i< tAngleCount; ++i)
					{
						AngleList.Add(context.Deserialize<PlAngleClipInfo>());
					}
				}

				StnTable = context.Deserialize<PlStnTable>();
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

		public PlPlayItem()
		{
			AngleList = new List<IPlClipInfo>();
		}
	}
}
