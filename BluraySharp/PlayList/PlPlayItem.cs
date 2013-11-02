using System;
using System.Collections.Generic;
using BluraySharp.Common;

namespace BluraySharp.Playlist
{
	public class PlPlayItem : IPlPlayItem
	{
		public byte StcId { get; set; }
		public BdTime InTime { get; set; }
		public BdTime OutTime { get; set; }

		public BdUOMask UOMask { get; private set; }
		public PlSeekingFlags SeekingFlags { get; private set; }
		public PlStillInfo StillInfo { get; private set; }
		public IPlArrangingInfo ArrangingInfo { get; private set; }
		public PlMultiAngleInfo MultiAngleInfo { get; private set; }

		public IList<PlAngleClipInfo> AngleList { get; private set; }

		public PlStnTable StnTable { get; private set; }

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
				PlAngleClipInfo tAngle = context.Deserialize<PlAngleClipInfo>();
				this.AngleList.Add(tAngle);

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
			get
			{
				long tDataLen = sizeof(ushort);

				tDataLen += sizeof(byte);
				tDataLen += this.InTime.RawLength;
				tDataLen += this.OutTime.RawLength;

				tDataLen += this.UOMask.RawLength;
				tDataLen += this.SeekingFlags.RawLength;

				tDataLen += this.StillInfo.RawLength;
				tDataLen += this.ArrangingInfo.RawLength;

				if (this.ArrangingInfo.IsMultiAngle && MultiAngleInfo != null)
				{
					tDataLen += this.MultiAngleInfo.RawLength;
				}

				foreach (IBdRawSerializable tObj in this.AngleList)
				{
					tDataLen += tObj.RawLength;
				}

				tDataLen += this.StnTable.RawLength;

				return tDataLen;
			}
		}

		public PlPlayItem()
		{
			AngleList = new List<PlAngleClipInfo>();
		}
	}
}
