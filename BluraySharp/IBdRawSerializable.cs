using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibElfin.WinApi.MemoryBlock;

namespace BluraySharp
{
	public interface IBdRawSerializable
	{
		long SerializeTo(BdRawSerializeContext context);
		long DeserializeFrom(BdRawSerializeContext context);
		long Length { get; }
	}
}
