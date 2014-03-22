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

using System;
using System.Collections.Generic;
using BluraySharp.Common;
using BluraySharp.Architecture;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	[BdPartScope(BdIntSize.U16)]
	public class PlPlayItem : BdPart, IPlPlayItem
	{
		#region MainAngle ClipFileRef

		private BdList<PlClipRef, IPlClipRef> angles =
			new BdList<PlClipRef, IPlClipRef>(0, 9) { new PlClipRef() };


		private IPlClipRef MainAngle
		{
			get
			{
				if (this.angles.Count == 0)
				{
					//MainAngle not specified;
					throw new ApplicationException();
				}

				return this.angles[this.angles.LowerBound];
			}
		}

		[BdSubPartField]
		private BdClipFileRef MainAngleClipFileRef
		{
			get
			{
				return this.MainAngle.ClipFileRef;
			}
		}

		#endregion

		#region ClipArrangingOptions

		private BdBitwise16 clipArrangingOptions = new BdBitwise16(1);

		[BdSubPartField]
		private BdBitwise16 ClipArrangingOptions
		{
			get
			{
				this.MultiAngleSkip = (this.angles.Count <= 1);
				return this.clipArrangingOptions;
			}
			set
			{
				this.clipArrangingOptions.Value = value.Value;
			}
		}
		public BdConnectionCondition ConnectionCondition
		{
			get { return (BdConnectionCondition) this.clipArrangingOptions[0, 4]; }
			set { this.clipArrangingOptions[0, 4] = (ushort) value; }
		}
		private bool MultiAngleSkip
		{
			get { return this.clipArrangingOptions[4, 1] == 0; }
			set { this.clipArrangingOptions[4, 1] = (ushort)(value ? 0 : 1); }
		}

		#endregion

		#region MainAngle StcIdRef
		[BdUIntField(BdIntSize.U8)]
		private byte StcIdRef
		{
			get { return this.MainAngle.StcIdRef; }
			set { this.MainAngle.StcIdRef = value; }
		}
		#endregion

		#region	InTime

		private BdTime inTime = new BdTime();

		[BdSubPartField]
		public BdTime InTime
		{
			get { return this.inTime; }
			set { this.inTime.Value = value.Value; }
		}

		#endregion

		#region OutTime

		private BdTime outTime = new BdTime();

		[BdSubPartField]
		public BdTime OutTime
		{
			get { return this.outTime; }
			set { this.outTime.Value = value.Value; }
		}

		#endregion

		#region UoMask

		private BdUOMask uoMask = new BdUOMask();

		[BdSubPartField]
		public BdUOMask UoMask
		{
			get { return this.uoMask; }
			set { this.uoMask.Value = value.Value; }
		}

		#endregion

		#region SeekingFlagValue

		private BdBitwise8 playbackOptioin = new BdBitwise8();

		[BdSubPartField]
		private BdBitwise8 PlaybackOptioin
		{
			get { return this.playbackOptioin; }
		}
		public bool RandomAccessFlag
		{
			get { return this.playbackOptioin[7, 1] == 1u; }
			set { this.playbackOptioin[7, 1] = (byte)(value ? 1 : 0); }
		}

		#endregion

		#region StillOptions

		private PlStillOptions stillOptions = new PlStillOptions();

		[BdSubPartField]
		public IPlStillOptions StillOptions
		{
			get { return this.stillOptions; }
		}

		#endregion

		#region AngleCount

		[BdUIntField(BdIntSize.U8, SkipIndicator = "MultiAngleSkip")]
		private byte AngleCount
		{
			get { return (byte)angles.Count; }
			set { this.angles.SetCount(value); }
		}

		#endregion

		#region MultiAngleOptions

		private BdBitwise8 multiAngleOptions = new BdBitwise8();

		[BdSubPartField(SkipIndicator = "MultiAngleSkip")]
		private BdBitwise8 MultiAngleOptions
		{
			get { return this.MultiAngleSkip ? null : this.multiAngleOptions; }
		}
		public bool IsMultiAngleDifferentAudios
		{
			get { return this.multiAngleOptions[1, 1] == 1; }
			set { this.multiAngleOptions[1, 1] = (byte)(value ? 1 : 0); }
		}
		public bool IsMultiAngleOptionsSeamlessChange
		{
			get { return this.multiAngleOptions[0, 1] == 1; }
			set { this.multiAngleOptions[0, 1] = (byte)(value ? 1 : 0); }
		}

		#endregion

		#region MultiAngles

		[BdSubPartField(SkipIndicator = "MultiAngleSkip")]
		private IBdList<IPlClipRef> MultiAngles
		{
			get
			{
				BdList<PlClipRef, IPlClipRef> tRet = new BdList<PlClipRef, IPlClipRef>(0, 9);
				for (int i = this.angles.LowerBound + 1; i < this.angles.UpperBound; ++i)
				{
					tRet.Add(this.angles[i]);
				}
				return tRet;
			}
		}
		public IBdList<IPlClipRef> ClipList
		{
			get { return this.angles; }
		}

		#endregion

		#region StnTable

		private PlStnTable stnTable = new PlStnTable();
		[BdSubPartField]
		public IPlStnTable StnTable
		{
			get { return this.stnTable; }
		}

		#endregion

		public override string ToString()
		{
			return "PlayItem";
		}
	}
}