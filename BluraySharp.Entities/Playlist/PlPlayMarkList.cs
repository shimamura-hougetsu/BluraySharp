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
	public class PlPlayMarkList : BdPart, IPlPlayMarkList
	{
		[BdUIntField(BdIntSize.U16)]
		private ushort MarkCount
		{
			get { return (ushort)this.MarkList.Count; }
			set { this.MarkList.SetCount(value); }
		}

		private IBdList<IPlPlayMark> markList =
			new BdList<PlPlayMark, IPlPlayMark>(0, 999) 
			{ 
				new PlPlayMark() { MarkType = PlPlayMarkType.PmEntryMark }
			};

		[BdSubPartField]
		public IBdList<IPlPlayMark> MarkList
		{
			get { return this.markList; }
		}

		public override string ToString()
		{
			return "PlayMarkList";
		}
	}
}
