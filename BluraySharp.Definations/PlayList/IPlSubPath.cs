using System;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public interface IPlSubPath : IBdPart
	{
		IBdList<IPlPlayItem> PlayItems { get; }
		BluraySharp.PlayList.PlSubPathType Type { get; set; }
	}
}
