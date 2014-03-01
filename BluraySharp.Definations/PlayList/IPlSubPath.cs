using BluraySharp.Common;
using BluraySharp.Common.Serializing;

namespace BluraySharp.PlayList
{
	public interface IPlSubPath : IBdPart
	{
		IBdList<IPlPlayItemInfo> PlayItems { get; }
		BluraySharp.PlayList.PlSubPathType Type { get; set; }
	}
}
