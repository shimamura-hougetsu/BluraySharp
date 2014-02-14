using BluraySharp.Common;
using System;
using System.Xml.Serialization;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public class PlAppInfo : BluraySharp.PlayList.IPlAppInfo
	{
		public PlPlaybackType PlaybackType
		{
			get { return playbackType; }
			set { playbackType = value; }
		}

		public ushort PlaybackCount
		{
			get { return playbackCount; }
			set { playbackCount = value; }
		}

		public BdUOMask UoMask
		{
			get { return uoMask; }
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				uoMask = value;
			}
		}

		public bool RandomAccessFlag
		{
			get;
			set;
		}
		public bool AudioMixAppFlag
		{
			get;
			set;
		}
		public bool LosslessMayBypassMixer
		{
			get;
			set;
		}

		private byte reservedForFutureUse1 = 0;
		private PlPlaybackType playbackType = PlPlaybackType.Sequential;
		private ushort playbackCount = 0;
		private BdUOMask uoMask = new BdUOMask();
		private BdBitwise16 playbackOption = new BdBitwise16(0);

		public long SerializeTo(IBdRawWriteContext context)
		{
			uint tDataLen = (uint) this.RawLength;
			context.Serialize(tDataLen);

			context.EnterScope(tDataLen);
			try
			{
				context.Serialize((byte)this.playbackType);
				context.Serialize(this.playbackCount);
				context.Serialize(this.uoMask);
				context.Serialize(this.playbackOption);
			}
			finally
			{
				context.ExitScope();
			}

			return context.Position;
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			uint tDataLen = context.DeserializeUInt32();

			context.EnterScope();
			try
			{
				this.reservedForFutureUse1 = context.DeserializeByte();

				this.playbackType = (PlPlaybackType)context.DeserializeByte();
				this.playbackCount = context.DeserializeUInt16();

				this.uoMask = context.Deserialize<BdUOMask>();

				this.playbackOption = context.Deserialize<BdBitwise16>();
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
				return
					sizeof(uint) +
					sizeof(byte) * 2 +
					sizeof(ushort) * 2 +
					UoMask.RawLength;
			}
		}
	}
}
