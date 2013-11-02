using System;

namespace BluraySharp.Playlist
{
	public interface IPlArrangingInfo : IBdRawSerializable
	{
		BluraySharp.Common.BdConnectionCondition ConnectionCondition { get; set; }
		bool IsMultiAngle { get; set; }
	}
}
