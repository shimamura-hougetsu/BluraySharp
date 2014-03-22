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

namespace BluraySharp.PlayList
{
	[BdPartScope(BdIntSize.U32)]
	public class PlSubPath : BdPart, IPlSubPath
	{
		#region ReservedForFutureUse1

		[BdUIntField(BdIntSize.U8)]
		private byte ReservedForFutureUse1 { get; set; }

		#endregion

		#region SubPath Type

		[BdUIntField(BdIntSize.U8)]
		public PlSubPathType Type { get; set; }

		#endregion

		#region RepeatOptions

		private BdBitwise16 repeatOptions = new BdBitwise16();
		[BdSubPartField]
		private BdBitwise16 RepeatOptions
		{
			get { return this.repeatOptions; }
		}
		public bool IsRepeat
		{
			get { return this.RepeatOptions[0, 1] == 1; }
			set { this.RepeatOptions[0, 1] = (ushort)(value ? 1 : 0); }
		}

		#endregion

		#region ReservedForFutureUse2

		[BdUIntField(BdIntSize.U8)]
		private byte ReservedForFutureUse2 { get; set; }

		#endregion

		#region SubPlayItemCount

		[BdUIntField(BdIntSize.U8)]
		private byte SubPlayItemCount
		{
			get { return (byte)this.PlayItems.Count; }
			set { this.PlayItems.SetCount(value); }
		}

		#endregion

		#region PlayItems

		private BdList<PlSubPlayItem, IPlSubPlayItem> playItems = 
			new BdList<PlSubPlayItem,IPlSubPlayItem>(0, 255);

		[BdSubPartField]
		public IBdList<IPlSubPlayItem> PlayItems
		{
			get { return this.playItems; }
		}

		#endregion

		public override string ToString()
		{
			return "SubPath";
		}
	}
}