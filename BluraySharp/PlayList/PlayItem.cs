using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class PlayItem : IBdRawSerializable, BluraySharp.PlayList.IPlayItemClip
	{
		public string ClipId
		{
			get;
			set;
		}

		public string ClipCodec
		{
			get;
			set;
		}

		public byte StcId
		{
			get;
			set;
		}

		public PlaybackArrangingFlags ArrangingFlags
		{
			get;
			private set;
		}

		public BdTime InTime
		{
			get;
			private set;
		}

		public BdTime OutTime
		{
			get;
			private set;
		}

		public UOMask UOMask
		{
			get;
			private set;
		}

		public PlaybackSeekingFlags SeekingFlags
		{
			get;
			private set;
		}

		public PlaybackStillInfo StillInfo
		{
			get;
			private set;
		}

		public MultiAngleInfo MultiAngleInfo
		{
			get;
			set;
		}

		public IList<PlaybackAngle> MultiAngleList
		{
			get;
			private set;
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
				ClipId = context.DeserializeString(5);
				ClipCodec = context.DeserializeString(4);

				ArrangingFlags = context.Deserialize<PlaybackArrangingFlags>();
				StcId = context.DeserializeByte();

				InTime = context.Deserialize<BdTime>();
				OutTime = context.Deserialize<BdTime>();
				UOMask = context.Deserialize<UOMask>();

				SeekingFlags = context.Deserialize<PlaybackSeekingFlags>();
				StillInfo = context.Deserialize<PlaybackStillInfo>();

				if (ArrangingFlags.IsMultiAngle)
				{
					byte tAngleCount = context.DeserializeByte();

					MultiAngleInfo = context.Deserialize<MultiAngleInfo>();

					for(byte i = 0; i< tAngleCount; ++i)
					{
						MultiAngleList.Add(context.Deserialize<PlaybackAngle>());
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

		public long Length
		{
			get { throw new NotImplementedException(); }
		}

		public PlayItem()
		{
			MultiAngleList = new List<PlaybackAngle>();
		}
	}
}
