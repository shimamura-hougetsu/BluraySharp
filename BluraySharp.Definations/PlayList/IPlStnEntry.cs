using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnEntry : IBdPart
	{
		PlStnEntryType EntryType { get; set; }
		IPlStnEntryInfo EntryInfo { get; }
	}
}
