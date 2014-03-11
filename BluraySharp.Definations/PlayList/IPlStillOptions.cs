using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStillOptions : IBdPart
	{
		PlStillMode StillMode { get; set; }
		ushort StillDuration { get; set; }
	}
}
