using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;
using System;
namespace BluraySharp.PlayList
{
	[BdPartScope(BdIntSize.U32, IndicatorField = "LengthIndicator")]
	public class PlPlayItemList : BdPart, IPlPlayItemList
	{
		#region Private Data Fields

		private uint lengthIndicator = 0;
		private ushort reservedForFutureUse = 0;
		private ushort playItemCount = 0;
		private ushort subPathCount = 0;

		private readonly BdList<PlPlayItem, IPlPlayItem> playItems = 
			new BdList<PlPlayItem, IPlPlayItem>(0, 999);
		private readonly BdList<PlSubPath, IPlSubPath> subPaths =
			new BdList<PlSubPath, IPlSubPath>(0, 255);

		#endregion Private Data Fields

		private uint LengthIndicator
		{
			get { return this.lengthIndicator; }
			set { this.lengthIndicator = value; }
		}

		[BdUIntField(BdIntSize.U16)]
		private ushort ReservedForFutureUse
		{
			get { return this.reservedForFutureUse; }
			set { this.reservedForFutureUse = value; }
		}
		
		[BdUIntField(BdIntSize.U16)]
		private ushort PlayItemCount
		{
			get { return (ushort)this.playItems.Count; }
			set { this.playItems.SetCount(value); }
		}

		[BdUIntField(BdIntSize.U16)]
		private ushort SubPathCount
		{
			get { return (ushort) this.subPaths.Count; }
			set { this.subPaths.SetCount(value); }
		}

		[BdSubPartField]
		public IBdList<IPlPlayItem> PlayItems
		{
			get { return this.playItems; }
		}

		[BdSubPartField]
		public IBdList<IPlSubPath> SubPaths
		{
			get { return this.subPaths; }
		}

		public override string ToString()
		{
			return "PlayItems and SubPaths";
		}
	}
}
