using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;
using System;

namespace BluraySharp.PlayList
{
	public class PlAppInfo : BdPart, IPlAppInfo
	{
		#region Private Data Fields

		private byte reservedForFutureUse1 = 0;
		private PlPlaybackType playbackType = PlPlaybackType.Sequential;
		private ushort playbackCount = 0;

		private BdUOMask uoMask = new BdUOMask();
		private BdBitwise16 playbackOptioin = new BdBitwise16();

		#endregion Private Data Fields

		[BdUIntField(BdIntSize.U8)]
		public byte ReservedForFutureUse1
		{
			get { return this.reservedForFutureUse1; }
			set { this.reservedForFutureUse1 = value; }
		}

		[BdUIntField(BdIntSize.U8)]
		public PlPlaybackType PlaybackType
		{
			get { return this.playbackType; }
			set { this.playbackType = value; }
		}

		[BdUIntField(BdIntSize.U16)]
		public ushort PlaybackCount
		{
			get { return this.playbackCount; }
			set { this.playbackCount = value; }
		}

		[BdSubPartField]
		public BdUOMask UoMask
		{
			get { return this.uoMask; }
			set
			{
				if (value.RefEquals(null))
				{
					throw new ArgumentNullException("value");
				}
				this.uoMask.Value = value.Value;
			}
		}

		[BdSubPartField]
		private BdBitwise16 PlaybackOptioin
		{
			get { return this.playbackOptioin; }
			set
			{
				if (value.RefEquals(null))
				{
					throw new ArgumentNullException("value");
				}
				this.playbackOptioin.Value = value.Value;
			}
		}

		public bool RandomAccessFlag { get; set; }
		public bool AudioMixAppFlag { get; set; }
		public bool LosslessMayBypassMixer { get; set; }

		public override string ToString()
		{
			return "Play List AppInfo";
		}
	}
}
