using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<PlPlaybackType>))]
	public enum PlPlaybackType : byte
	{
		Unknown = 0x00,

		Sequential = 1,
		Random = 2,
		Shuffle = 3,
	}
}
