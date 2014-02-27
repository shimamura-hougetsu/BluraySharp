﻿using System.Collections.Generic;
using BluraySharp.Serializing;
using BluraySharp.Common;


namespace BluraySharp.PlayList
{
	public interface IPlPlayItemInfo : IBdPart
	{
		byte StcId { get; set; }
		BdTime InTime { get; set; }
		BdTime OutTime { get; set; }

		BdConnectionCondition ConnectionCondition { get; set; }
		IBdList<IPClipInfo> ClipList { get; }
	}
}