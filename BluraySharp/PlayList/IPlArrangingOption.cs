using System;
using BluraySharp.Common;

namespace BluraySharp.Playlist
{
	public interface IPlArrangingOption : IBdRawSerializable
	{
		BdConnectionCondition ConnectionCondition { get; set; }
		bool IsMultiAngle { get; set; }
	}
}
