using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public interface IPlStnSubPlayItemStreamEntryFields : IPlStnStreamEntry
	{
		byte SubPathId { get; set; }
		byte SubClipEntryId { get; set; }

		ushort StreamProgId { get; set; }
	}
}
