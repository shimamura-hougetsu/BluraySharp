using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<PlPlaybackType>))]
	public enum PlPlaybackType : byte
	{
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown = 0x00,

		Sequential = 1,
		Random = 2,
		Shuffle = 3,
	}
}
