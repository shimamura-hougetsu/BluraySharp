using System;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public interface IPlSubPath : IBdPart
	{
		System.Collections.Generic.IList<BluraySharp.PlayList.IPlPlayItem> PlayItems { get; }
		BluraySharp.PlayList.PlSubPathType Type { get; set; }

		IPlPlayItem CreateSubPlayItem();
	}
}
