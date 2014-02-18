using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Architecture
{
	public enum BdPartFieldType
	{
		Unknown,
		UInt,
		ByteArray,
		BdPart,
	}

	public enum BdIntSize : int
	{
		Auto = 0,

		BYTE = 1,
		WORD = 2,
		DWORD = 4,
		QWORD = 8,

		U8 = 1,
		U16 = 2,
 		U32 = 4,
		U64 = 8,
	}
}
