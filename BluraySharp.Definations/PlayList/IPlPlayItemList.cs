using System;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public interface IPlPlayItemList : IBdPart
	{
		IBdList<IPlPlayItem> PlayItems { get; }
		IBdList<IPlSubPath> SubPaths { get; }
	}
}
