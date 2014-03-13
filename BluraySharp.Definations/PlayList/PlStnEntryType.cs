
namespace BluraySharp.PlayList
{
	public enum PlStnEntryType : byte
	{
		Unknown,

		/// <summary>
		/// Stream from PlayItem
		/// </summary>
		PlayItem = 0x01,

		/// <summary>
		/// Stream from SubPath.SubPlayItem
		/// </summary>
		SubPlayItem = 0x02,

		/// <summary>
		/// Stream as Pip from PlayItem
		/// </summary>
		InMuxPip = 0x03,

	}
}
