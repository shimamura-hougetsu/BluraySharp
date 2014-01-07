using BluraySharp.Common;
using System;
using System.Xml.Serialization;

namespace BluraySharp.Playlist
{
	[XmlRoot("AppInfoPlayList")]
	public class PlAppInfo : BluraySharp.Playlist.IPlAppInfo
	{
		[XmlElement(ElementName="PlayList_playback_type", Type=typeof(byte))]
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
		private BdBitwise16 _PlaybackOption = new BdBitwise16(0);

		public long SerializeTo(IBdRawSerializeContext context)
		{
			uint tDataLen = (uint) this.RawLength;
			context.Serialize(tDataLen);

			context.EnterScope(tDataLen);
			try
			{
				context.Serialize((byte)this.playbackType);
				context.Serialize(this.playbackCount);
				context.Serialize<BdUOMask>(this.uoMask);
				context.Serialize<BdBitwise16>(this._PlaybackOption);
			}
			finally
			{
				context.ExitScope();
			}

			return context.Offset += tDataLen;
		}

		public long DeserializeFrom(IBdRawSerializeContext context)
		{
			uint tDataLen = context.DeserializeUInt32();

			context.EnterScope();
			try
			{
				this.reservedForFutureUse1 = context.DeserializeByte();

				this.playbackType = (PlPlaybackType)context.DeserializeByte();
				this.playbackCount = context.DeserializeUInt16();

				this.uoMask = context.Deserialize<BdUOMask>();

				this._PlaybackOption = context.Deserialize<BdBitwise16>();
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
				return
					sizeof(uint) +
					sizeof(byte) * 2 +
					sizeof(ushort) * 2 +
					UoMask.RawLength;
			}
		}
	}
}
