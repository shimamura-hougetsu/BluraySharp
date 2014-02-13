using System;
using System.Collections.Generic;
using BluraySharp.Common;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public class PlPlayItem : IPlPlayItem
	{
		public IBdList<IPlAngleClipInfo> AngleList { get; internal set; }

		public byte StcId { get; set; }
		public BdTime InTime { get; set; }
		public BdTime OutTime { get; set; }

		public BdConnectionCondition ConnectionCondition
		{
			get
			{
				return (BdConnectionCondition)arrangingOption[0, 4];
			}
			set
			{
				arrangingOption[0, 4] = (ushort)value;
			}
		}

		public bool IsMultiAngle
		{
			get
			{
				return arrangingOption[4, 1] == 1;
			}
			set
			{
				arrangingOption[4, 1] = (ushort) (value ? 1u : 0u);
			}
		}

		public BdUOMask UoMask { get; internal set; }

		public bool RandomAccessProhibited
		{
			get
			{
				return this.seekingFlagValue[7, 1] == 1u;
			}
			set
			{
				this.seekingFlagValue[7, 1] = (byte) (value ? 1 : 0);
			}
		}

		internal BdBitwise8 seekingFlagValue = new BdBitwise8();

		public IPlStillInfo StillInfo { get; internal set; }

		internal BdBitwise16 arrangingOption = new BdBitwise16();
		internal BdBitwise8 multiAngleOption = new BdBitwise8();
		
		public IPlStnTable StnTable { get; internal set; }

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
				this.AngleList.Clear();

				PlAngleClipInfo tAngle = context.Deserialize<PlAngleClipInfo>();
				this.AngleList.Insert(tAngle);

				arrangingOption = context.Deserialize<BdBitwise16>();
				StcId = context.DeserializeByte();

				InTime = context.Deserialize<BdTime>();
				OutTime = context.Deserialize<BdTime>();
				UoMask = context.Deserialize<BdUOMask>();

				seekingFlagValue = context.Deserialize<BdBitwise8>();
				StillInfo = context.Deserialize<PlStillInfo>();

				if (this.IsMultiAngle)
				{
					byte tAngleCount = context.DeserializeByte();

					multiAngleOption = context.Deserialize<BdBitwise8>();

					if (tAngleCount < 1)
					{
						tAngleCount = 1;
					}

					for(byte i = 0; i< tAngleCount; ++i)
					{
						AngleList.Insert(context.Deserialize<PlAngleClipInfo>());
					}
				}

				StnTable = context.Deserialize<PlStnTable>();
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

				tDataLen += this.UoMask.RawLength;
				tDataLen += this.seekingFlagValue.RawLength;

				tDataLen += this.StillInfo.RawLength;
				tDataLen += this.arrangingOption.RawLength;

				if (this.IsMultiAngle && multiAngleOption != null)
				{
					tDataLen += this.multiAngleOption.RawLength;
				}

				foreach (IBdPart tObj in this.AngleList)
				{
					tDataLen += tObj.RawLength;
				}

				tDataLen += this.StnTable.RawLength;

				return tDataLen;
			}
		}

		public PlPlayItem()
		{
			this.AngleList = new BdPartList<PlAngleClipInfo, IPlAngleClipInfo>(9);
			this.InTime = new BdTime();
			this.OutTime = new BdTime();
		}
	}
}
