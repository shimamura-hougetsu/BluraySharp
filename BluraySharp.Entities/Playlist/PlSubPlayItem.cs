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
	[BdPartScope(BdIntSize.U16)]
	public class PlSubPlayItem : BdPart, IPlSubPlayItem
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

		private BdBitwise32 clipArrangingOptions = new BdBitwise32(0x20);

		[BdSubPartField]
		private BdBitwise32 ClipArrangingOptions
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
			get { return (BdConnectionCondition)this.clipArrangingOptions[1, 4]; }
			set { this.clipArrangingOptions[1, 4] = (uint)value; }
		}
		private bool MultiAngleSkip
		{
			get { return this.clipArrangingOptions[0, 1] == 0; }
			set { this.clipArrangingOptions[0, 1] = (uint)(value ? 0 : 1); }
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

		#region SyncOptions to PlayItem

		[BdUIntField(BdIntSize.U16)]
		public ushort SyncPlayItemId { get; set; }

		private BdTime syncPlayTime = new BdTime();

		[BdSubPartField]
		public BdTime SyncPlayTime
		{
			get { return this.syncPlayTime; }
			set { this.syncPlayTime.Value = value.Value; }
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

		#region ReservedForFutureUse

		[BdUIntField(BdIntSize.U8, SkipIndicator = "MultiAngleSkip")]
		private byte ReservedForFutureUse { get; set; }

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

		public override string ToString()
		{
			return "SubPath Play Item";
		}
	}
}