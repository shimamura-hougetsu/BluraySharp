using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlayItem : IBdRawSerializable, IPlayItem
	{
		public byte StcId { get; set; }
		public BdTime InTime { get; set; }
		public BdTime OutTime { get; set; }

		public BdUOMask UOMask { get; private set; }
		public PlaybackSeekingFlags SeekingFlags { get; private set; }

		public PlaybackStillInfo StillInfo { get; private set; }

		public ArrangingInfo ArrangingInfo { get; private set; }

		public MultiAngleInfo MultiAngleInfo { get; private set; }

		public IList<IClipReferance> AngleList { get; private set; }
		public void AddAngle(string codec, string id)
		{
			PlaybackAngle tAngle = new PlaybackAngle() { ClipCodec = codec, ClipId = id };
			AngleList.Add(tAngle);
		}

		public StnTable StnTable
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

				ArrangingInfo = context.Deserialize<ArrangingInfo>();
				StcId = context.DeserializeByte();

				InTime = context.Deserialize<BdTime>();
				OutTime = context.Deserialize<BdTime>();
				UOMask = context.Deserialize<BdUOMask>();

				SeekingFlags = context.Deserialize<PlaybackSeekingFlags>();
				StillInfo = context.Deserialize<PlaybackStillInfo>();

				if (ArrangingInfo.IsMultiAngle)
				{
					byte tAngleCount = context.DeserializeByte();

					MultiAngleInfo = context.Deserialize<MultiAngleInfo>();

					if (tAngleCount < 1)
					{
						tAngleCount = 1;
					}

					for(byte i = 0; i< tAngleCount; ++i)
					{
						AngleList.Add(context.Deserialize<PlaybackAngle>());
					}
				}

				StnTable = context.Deserialize<StnTable>();
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

		public PlayItem()
		{
			AngleList = new List<IClipReferance>();
		}
	}
}
