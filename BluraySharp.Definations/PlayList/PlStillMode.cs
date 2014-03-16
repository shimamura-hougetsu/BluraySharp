using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<PlStillMode>))]
	public enum PlStillMode
	{
		NotStill = 0x0,
		StillForDuration = 0x1,
		StillInfinitely = 0x2,
	}
}
