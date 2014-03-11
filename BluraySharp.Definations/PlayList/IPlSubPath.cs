using BluraySharp.Common;
using BluraySharp.Common.Serializing;

namespace BluraySharp.PlayList
{
	public interface IPlSubPath : IBdPart
	{
		PlSubPathType Type { get; set; }
		bool IsRepeat { get; set; }
		IBdList<IPlSubPlayItem> PlayItems { get; }
	}
}
