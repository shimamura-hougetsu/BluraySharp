using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public interface IPlStnSubPlayItemStreamEntryProperties : IPlStnStreamEntry
	{
		byte SubPathId { get; set; }
		byte SubClipEntryId { get; set; }
	}
}
