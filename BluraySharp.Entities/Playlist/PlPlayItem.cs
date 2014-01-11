using System;
using System.Collections.Generic;
using BluraySharp.Common;

namespace BluraySharp.Playlist
{
	public class PlPlayItem : IPlPlayItem
	{
		public IList<IPlAngleClipInfo> AngleList
		{
			get { throw new NotImplementedException(); }
		}


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

		public BdUOMask UoMask { get; private set; }
		public PlSeekingFlags SeekingFlags { get; private set; }
		public PlStillInfo StillInfo { get; private set; }

		private BdBitwise16 arrangingOption = new BdBitwise16();

		private BdBitwise8 multiAngleOption = new BdBitwise8();

		public IList<PlAngleClipInfo> AngleListX { get; private set; }
		
		public IPlAngleClipInfo CreateAngleClipInfo()
		{
			return new PlAngleClipInfo();
		}

		public PlStnTable StnTable { get; private set; }

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
				this.AngleListX.Clear();
				PlAngleClipInfo tAngle = context.Deserialize<PlAngleClipInfo>();
				this.AngleListX.Add(tAngle);

				arrangingOption = context.Deserialize<BdBitwise16>();
				StcId = context.DeserializeByte();

				InTime = context.Deserialize<BdTime>();
				OutTime = context.Deserialize<BdTime>();
				UoMask = context.Deserialize<BdUOMask>();

				//TODO: random_access_flag
				SeekingFlags = context.Deserialize<PlSeekingFlags>();
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
						AngleListX.Add(context.Deserialize<PlAngleClipInfo>());
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

				tDataLen += this.UoMask.RawLength;
				tDataLen += this.SeekingFlags.RawLength;

				tDataLen += this.StillInfo.RawLength;
				tDataLen += this.arrangingOption.RawLength;

				if (this.IsMultiAngle && multiAngleOption != null)
				{
					tDataLen += this.multiAngleOption.RawLength;
				}

				foreach (IBdObject tObj in this.AngleListX)
				{
					tDataLen += tObj.RawLength;
				}

				tDataLen += this.StnTable.RawLength;

				return tDataLen;
			}
		}

		public PlPlayItem()
		{
			AngleListX = new List<PlAngleClipInfo>();
		}

	}
}
