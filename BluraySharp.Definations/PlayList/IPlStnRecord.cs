using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnRecord : IBdPart
	{
		PlStnStreamEntryType EntryType { get; set; }
		IPlStnStreamEntry Entry { get; }
	}
}
