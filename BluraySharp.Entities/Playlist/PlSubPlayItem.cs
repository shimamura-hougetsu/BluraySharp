using System;
using System.Collections.Generic;
using BluraySharp.Common;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public class PlSubPlayItem : IPlPlayItemInfo
	{
		public byte StcId { get; set; }
		public BdTime InTime { get; set; }
		public BdTime OutTime { get; set; }

		public IBdList<IPlAngleClipInfo> AngleList
		{
			get 
			{
				return this.AngleListX;
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

		public BdPartList<PlAngleClipInfo, IPlAngleClipInfo> AngleListX { get; private set; }

		public IPlAngleClipInfo CreateAngleClipInfo()
		{
			return new PlAngleClipInfo();
		}

		public long SerializeTo(IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			ushort tDataLen;

			tDataLen = context.DeserializeUInt16();
			context.EnterScope(tDataLen);

			try
			{
				PlAngleClipInfo tAngle = context.Deserialize<PlAngleClipInfo>();
				this.AngleList.Insert(tAngle);

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
						AngleList.Insert(context.Deserialize<PlAngleClipInfo>());
					}
				}
			}
			finally
			{
				context.ExitScope();
			}

			return context.Position;
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

				foreach (IBdPart tObj in this.AngleList)
				{
					tDataLen += tObj.RawLength;
				}

				return tDataLen;
			}
		}

		public PlSubPlayItem()
		{
			this.AngleListX = new BdPartList<PlAngleClipInfo, IPlAngleClipInfo>(255);
			this.InTime = new BdTime();
			this.OutTime = new BdTime();
			this.SyncPlayTimeOffset = new BdTime();
		}
	}
}
