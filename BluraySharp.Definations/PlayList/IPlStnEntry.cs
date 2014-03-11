using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnEntry : IBdPart
	{
		PlStnStreamEntryType EntryType { get; set; }
		IPlStnEntryInfo EntryInfo { get; }
	}
}
