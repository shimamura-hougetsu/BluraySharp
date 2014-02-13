using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlPlayItem : IPlPlayItemInfo
	{
		BdUOMask UoMask { get; }

		bool RandomAccessProhibited { get; set; }
		IPlStillInfo StillInfo { get; }

		IPlStnTable StnTable { get; }
	}
}
