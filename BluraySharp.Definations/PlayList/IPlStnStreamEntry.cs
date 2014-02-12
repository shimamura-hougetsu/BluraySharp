using System;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public interface IPlStnStreamEntry : IBdPart
	{
		ushort StreamProgId { get; set; }
	}
}
