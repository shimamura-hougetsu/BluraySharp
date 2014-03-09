using System;
using System.Collections.Generic;
using BluraySharp.Common;
using BluraySharp.Architecture;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	[BdPartScope(BdIntSize.U16, IndicatorField = "LengthIndicator")]
	public class PlPlayItem : BdPart, IPlPlayItem
	{
		#region Private Data Fields

		private uint lengthIndicator = 0;
		private BdPartList<PlClipRef, IPlClipRef> angles =
			new BdPartList<PlClipRef, IPlClipRef>(0, 9) { new PlClipRef() };
		private BdBitwise16 clipArrangingOptions = new BdBitwise16();

		private BdTime inTime = new BdTime();
		private BdTime outTime = new BdTime();
		private BdUOMask uoMask = new BdUOMask();

		private BdBitwise8 seekingFlagValue = new BdBitwise8();
		private PlStillOptions stillOptions = new PlStillOptions();

		private byte angleCount = 1;
		private BdBitwise8 multiAngleOptions = new BdBitwise8();

		private PlStnTable stnTable = new PlStnTable();

		private bool multiAngleSkip = true;

		#endregion

		private uint LengthIndicator
		{
			get { return this.lengthIndicator; }
			set { this.lengthIndicator = value; }
		}

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
		private IPlClipFileRef MainAngleClipFileRef
		{
			get
			{
				return this.MainAngle.ClipFileRef;
			}
		}

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
		
		[BdUIntField(BdIntSize.U8)]
		public byte StcId
		{
			get { return this.MainAngle.StcId; }
			set { this.MainAngle.StcId = value; }
		}

		[BdSubPartField]
		public BdTime InTime
		{
			get { return this.inTime; }
			set { this.inTime.Value = value.Value; }
		}

		[BdSubPartField]
		public BdTime OutTime
		{
			get { return this.outTime; }
			set { this.outTime.Value = value.Value; }
		}

		[BdSubPartField]
		public BdUOMask UoMask
		{
			get { return this.uoMask; }
			set { this.uoMask.Value = value.Value; }
		}

		[BdSubPartField]
		private BdBitwise8 SeekingFlagValue
		{
			get { return this.seekingFlagValue; }
		}
		public bool RandomAccessProhibited
		{
			get { return this.seekingFlagValue[7, 1] == 1u; }
			set { this.seekingFlagValue[7, 1] = (byte)(value ? 1 : 0); }
		}

		[BdSubPartField]
		public IPlStillOptions StillOptions
		{
			get { return this.stillOptions; }
		}

		[BdUIntField(BdIntSize.U8, SkipIndicator = "MultiAngleSkip")]
		private byte AngleCount
		{
			get
			{
				this.angleCount = (byte)angles.Count;
				return this.angleCount;
			}
			set
			{
				this.angles.SetCount(value);
			}
		}

		[BdSubPartField(SkipIndicator = "MultiAngleSkip")]
		private BdBitwise8 MultiAngleOptions
		{
			get { return this.multiAngleOptions; }
		}

		[BdSubPartField(SkipIndicator = "MultiAngleSkip")]
		private IBdList<IPlClipRef> MultiAngles
		{
			get
			{
				BdPartList<PlClipRef, IPlClipRef> tRet = new BdPartList<PlClipRef, IPlClipRef>(0, 9);
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

		[BdSubPartField]
		public IPlStnTable StnTable
		{
			get { return this.stnTable; }
		}

		public override string ToString()
		{
			return "PlayItem";
		}
	}
}