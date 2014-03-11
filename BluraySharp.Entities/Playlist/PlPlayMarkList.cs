using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;
using System;

namespace BluraySharp.PlayList
{
	/// <summary>
	/// Not Implemented Yet
	/// </summary>
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
				new PlPlayMark() { MarkType = BdPlayMarkType.PmEntryMark }
			};

		[BdSubPartField]
		IBdList<IPlPlayMark> MarkList
		{
			get { return this.markList; }
		}

		public override string ToString()
		{
			return "PlayMarkList";
		}
	}
}
