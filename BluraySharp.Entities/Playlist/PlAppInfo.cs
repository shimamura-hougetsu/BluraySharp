/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at Google Code (https://code.google.com/p/bluray-sharp/)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/

using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;
using System;

namespace BluraySharp.PlayList
{
	[BdPartScope(BdIntSize.U32)]
	public class PlAppInfo : BdPart, IPlAppInfo
	{
		#region ReservedForFutureUse1

		[BdUIntField(BdIntSize.U8)]
		public byte ReservedForFutureUse1 { get; set; }
		
		#endregion 

		#region PlaybackType

		private PlPlaybackType playbackType = PlPlaybackType.Sequential;

		[BdUIntField(BdIntSize.U8)]
		public PlPlaybackType PlaybackType
		{
			get { return this.playbackType; }
			set { this.playbackType = value; }
		}

		#endregion PlaybackCount

		#region PlaybackCount
		private ushort playbackCount = 0;

		[BdUIntField(BdIntSize.U16)]
		public ushort PlaybackCount
		{
			get
			{
				return (ushort) (
					(this.PlaybackType == PlPlaybackType.Sequential) ?
					  0 :
					  this.playbackCount);
			}
			set { this.playbackCount = value; }
		}

		#endregion

		#region UoMask

		private BdUOMask uoMask = new BdUOMask();

		[BdSubPartField]
		public BdUOMask UoMask
		{
			get { return this.uoMask; }
			set
			{
				if (value.IsNull())
				{
					throw new ArgumentNullException("value");
				}
				this.uoMask.Value = value.Value;
			}
		}

		#endregion

		#region PlaybackOptioin

		private BdBitwise16 playbackOptioin = new BdBitwise16();

		[BdSubPartField]
		private BdBitwise16 PlaybackOptioin
		{
			get { return this.playbackOptioin; }
			set
			{
				if (value.IsNull())
				{
					throw new ArgumentNullException("value");
				}
				this.playbackOptioin.Value = value.Value;
			}
		}
		public bool RandomAccessFlag
		{
			get { return this.PlaybackOptioin[15, 1] == 1; }
			set { this.PlaybackOptioin[15, 1] = (ushort)(value ? 1 : 0); }
		}
		public bool AudioMixAppFlag
		{
			get { return this.PlaybackOptioin[14, 1] == 1; }
			set { this.PlaybackOptioin[14, 1] = (ushort)(value ? 1 : 0); }
		}
		public bool LosslessMayBypassMixer
		{
			get { return this.PlaybackOptioin[13, 1] == 1; }
			set { this.PlaybackOptioin[13, 1] = (ushort)(value ? 1 : 0); }
		}

		#endregion

		public override string ToString()
		{
			return "Play List AppInfo";
		}
	}
}
