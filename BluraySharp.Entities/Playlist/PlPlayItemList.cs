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
	public class PlPlayItemList : BdPart, IPlPlayItemList
	{
		#region ReservedForFutureUse

		[BdUIntField(BdIntSize.U16)]
		private ushort ReservedForFutureUse { get; set; }

		#endregion

		#region PlayItemCount
		[BdUIntField(BdIntSize.U16)]
		private ushort PlayItemCount
		{
			get { return (ushort)this.playItems.Count; }
			set { this.playItems.SetCount(value); }
		}

		#endregion

		#region SubPathCount
		[BdUIntField(BdIntSize.U16)]
		private ushort SubPathCount
		{
			get { return (ushort) this.subPaths.Count; }
			set { this.subPaths.SetCount(value); }
		}

		#endregion

		#region PlayItems
		private readonly BdList<PlPlayItem, IPlPlayItem> playItems =
			new BdList<PlPlayItem, IPlPlayItem>(0, 999)
			{ new PlPlayItem() };

		[BdSubPartField]
		public IBdList<IPlPlayItem> PlayItems
		{
			get { return this.playItems; }
		}

		#endregion

		#region SubPaths

		private readonly BdList<PlSubPath, IPlSubPath> subPaths =
			new BdList<PlSubPath, IPlSubPath>(0, 255);

		[BdSubPartField]
		public IBdList<IPlSubPath> SubPaths
		{
			get { return this.subPaths; }
		}

		#endregion
		
		public override string ToString()
		{
			return "PlayItems and SubPaths";
		}
	}
}
