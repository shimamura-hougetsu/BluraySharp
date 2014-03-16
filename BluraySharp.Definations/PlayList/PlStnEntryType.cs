
using BluraySharp.Common;
namespace BluraySharp.PlayList
{
	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<PlStnEntryType>))]
	public enum PlStnEntryType : byte
	{
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
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
