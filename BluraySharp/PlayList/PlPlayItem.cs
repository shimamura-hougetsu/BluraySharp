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

		public BdConnectionCondition ConnectionCondition
		{
			get
			{
				return (BdConnectionCondition)_ArrangingOption[0, 4];
			}
			set
			{
				_ArrangingOption[0, 4] = (ushort)value;
			}
		}

		public bool IsMultiAngle
		{
			get
			{
				return _ArrangingOption[4, 1] == 1;
			}
			set
			{
				_ArrangingOption[4, 1] = (ushort) (value ? 1u : 0u);
			}
		}

		public BdUOMask UOMask { get; private set; }
		public PlSeekingFlags SeekingFlags { get; private set; }
		public PlStillInfo StillInfo { get; private set; }

		private BdBitwise16 _ArrangingOption = new BdBitwise16();

		private BdBitwise8 _MultiAngleOption = new BdBitwise8();

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

				_ArrangingOption = context.Deserialize<BdBitwise16>();
				StcId = context.DeserializeByte();

				InTime = context.Deserialize<BdTime>();
				OutTime = context.Deserialize<BdTime>();
				UOMask = context.Deserialize<BdUOMask>();

				SeekingFlags = context.Deserialize<PlSeekingFlags>();
				StillInfo = context.Deserialize<PlStillInfo>();

				if (this.IsMultiAngle)
				{
					byte tAngleCount = context.DeserializeByte();

					_MultiAngleOption = context.Deserialize<BdBitwise8>();

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
				tDataLen += this._ArrangingOption.RawLength;

				if (this.IsMultiAngle && _MultiAngleOption != null)
				{
					tDataLen += this._MultiAngleOption.RawLength;
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
