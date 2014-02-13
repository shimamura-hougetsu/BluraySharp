using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public interface IPlStillInfo : IBdPart
	{
		PlStillMode StillMode { get; set; }
		ushort StillDuration { get; set; }
	}
}
