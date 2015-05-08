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
	public class PlPlayMark : BdPart, IPlPlayMark
	{
		[BdUIntField(BdIntSize.U8)]
		private byte ReservedForFutureUse { get; set; }

		[BdUIntField(BdIntSize.U8)]
		public PlPlayMarkType MarkType { get; set; }

		[BdUIntField(BdIntSize.U16)]
		public ushort PlayItemId { get; set; }


		private BdTime timeStamp = new BdTime();
		[BdSubPartField]
		public BdTime TimeStamp
		{
			get { return this.timeStamp; }
			set { this.timeStamp.Value = value.Value; }
		}

		[BdUIntField(BdIntSize.U16)]
		public ushort StreamProgId { get; set; }

		[BdUIntField(BdIntSize.U32)]
		public uint Duration { get; set; }

		public override string ToString()
		{
			return "PlayMark";
		}
	}
}
