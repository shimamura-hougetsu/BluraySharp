using System;
using System.Collections.Generic;
using BluraySharp.Common;

namespace BluraySharp.Playlist
{
	public class PlSubPlayItem : IPlPlayItem
	{
		public byte StcId { get; set; }
		public BdTime InTime { get; set; }
		public BdTime OutTime { get; set; }

		public ushort SyncPlayItemId { get; set; }
		public BdTime SyncPlayTimeOffset { get; set; }

		private PlSubPlayItemArrangingOption _ArrangingOption = new PlSubPlayItemArrangingOption();
		public IPlArrangingOption ArrangingOption
		{
			get
			{
				return _ArrangingOption;
			}
		}

		public IList<PlAngleClipInfo> AngleList { get; private set; }

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

				_ArrangingOption = context.Deserialize<PlSubPlayItemArrangingOption>();
				StcId = context.DeserializeByte();

				InTime = context.Deserialize<BdTime>();
				OutTime = context.Deserialize<BdTime>();

				SyncPlayItemId = context.DeserializeUInt16();
				SyncPlayTimeOffset = context.Deserialize<BdTime>();

				if (ArrangingOption.IsMultiAngle)
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
			get
			{
				long tDataLen = sizeof(ushort);

				tDataLen += sizeof(byte);
				tDataLen += this.InTime.RawLength;
				tDataLen += this.OutTime.RawLength;

				tDataLen += this._ArrangingOption.RawLength;

				foreach (IBdRawSerializable tObj in this.AngleList)
				{
					tDataLen += tObj.RawLength;
				}

				return tDataLen;
			}
		}

		public PlSubPlayItem()
		{
			this.AngleList = new List<PlAngleClipInfo>();
		}
	}
}
