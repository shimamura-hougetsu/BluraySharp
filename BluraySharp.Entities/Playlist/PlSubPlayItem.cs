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

		public IList<IPlAngleClipInfo> AngleList
		{
			get 
			{
				return new List<IPlAngleClipInfo>(this.AngleListX); 
			}
		}

		public BdConnectionCondition ConnectionCondition
		{
			get
			{
				return (BdConnectionCondition) arrangingOption[1, 4];
			}
			set
			{
				arrangingOption[1, 4] = (uint)value;
			}
		}
		public bool IsMultiAngle
		{
			get
			{
				return arrangingOption[0, 1] == 1;
			}
			set
			{
				arrangingOption[0, 1] = (value ? 1u : 0u);
			}
		}

		public ushort SyncPlayItemId { get; set; }
		public BdTime SyncPlayTimeOffset { get; set; }

		private BdBitwise32 arrangingOption = new BdBitwise32();

		public IList<PlAngleClipInfo> AngleListX { get; private set; }

		public IPlAngleClipInfo CreateAngleClipInfo()
		{
			return new PlAngleClipInfo();
		}

		public long SerializeTo(IBdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawSerializeContext context)
		{
			ushort tDataLen;

			tDataLen = context.DeserializeUInt16();
			context.EnterScope(tDataLen);

			try
			{
				PlAngleClipInfo tAngle = context.Deserialize<PlAngleClipInfo>();
				this.AngleList.Add(tAngle);

				arrangingOption = context.Deserialize<BdBitwise32>();
				StcId = context.DeserializeByte();

				InTime = context.Deserialize<BdTime>();
				OutTime = context.Deserialize<BdTime>();

				SyncPlayItemId = context.DeserializeUInt16();
				SyncPlayTimeOffset = context.Deserialize<BdTime>();

				if (this.IsMultiAngle)
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

				tDataLen += this.arrangingOption.RawLength;

				foreach (IBdObject tObj in this.AngleList)
				{
					tDataLen += tObj.RawLength;
				}

				return tDataLen;
			}
		}

		public PlSubPlayItem()
		{
			this.AngleListX = new List<PlAngleClipInfo>();
		}
	}
}
