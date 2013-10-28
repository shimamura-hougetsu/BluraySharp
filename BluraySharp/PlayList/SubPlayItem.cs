using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class SubPlayItem : IPlayItemClip, IBdRawSerializable
	{
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

				SyncPlayItemId = context.DeserializeUInt16();
				SyncPlayTimeOffset = context.Deserialize<BdTime>();

				if (ArrangingFlags.IsMultiAngle)
				{
					byte tAngleCount = context.DeserializeByte();

					for (byte i = 0; i < tAngleCount; ++i)
					{
						MultiAngleList.Add(context.Deserialize<PlaybackAngle>());
					}
				}
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

		public PlaybackArrangingFlags ArrangingFlags { get; set; }

		public string ClipCodec { get; set; }

		public string ClipId { get; set; }

		public BdTime InTime { get; set; }

		public IList<PlaybackAngle> MultiAngleList { get; private set; }

		public BdTime OutTime { get; set; }

		public byte StcId { get; set; }

		public ushort SyncPlayItemId { get; set; }

		public BdTime SyncPlayTimeOffset { get; set; }
	}
}
