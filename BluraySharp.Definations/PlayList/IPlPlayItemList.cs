using System;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public interface IPlPlayItemList : IBdPart
	{
		System.Collections.Generic.IList<BluraySharp.PlayList.IPlPlayItem> PlayItems { get; }
		System.Collections.Generic.IList<BluraySharp.PlayList.IPlSubPath> SubPaths { get; }

		IPlPlayItem CreatePlayItem();
		IPlSubPath CreateSubPath();
	}
}
