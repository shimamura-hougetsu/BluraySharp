using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlPlayMarkList : IBdPart
	{
		uint LengthIndicator { get; set; }
	}
}
