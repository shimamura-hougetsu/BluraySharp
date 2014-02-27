using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlPlayItemList : IBdPart
	{
		IBdList<IPlPlayItem> PlayItems { get; }
		IBdList<IPlSubPath> SubPaths { get; }
	}
}
