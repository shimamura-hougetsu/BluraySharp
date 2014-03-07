using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;
using System;
namespace BluraySharp.PlayList
{
	public class PlPlayItemList : BdPart, IPlPlayItemList
	{
		#region Private Data Fields

		private ushort reservedForFutureUse = 0;
		private ushort playItemCount = 0;
		private ushort subPathCount = 0;

		private readonly BdPartList<PlPlayItem, IPlPlayItem> playItems = 
			new BdPartList<PlPlayItem, IPlPlayItem>(0, 999);
		private readonly BdPartList<PlSubPath, IPlSubPath> subPaths =
			new BdPartList<PlSubPath, IPlSubPath>(0, 255);

		#endregion Private Data Fields

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
			set { this.playItems.SetLength(value); }
		}

		[BdUIntField(BdIntSize.U16)]
		private ushort SubPathCount
		{
			get { return (ushort) this.subPaths.Count; }
			set { this.subPaths.SetLength(value); }
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
