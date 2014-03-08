
namespace BluraySharp.Common
{
	public enum BdIntSize : byte
	{
		None = 0,

		BYTE = 1,
		WORD = 2,
		DWORD = 4,
		QWORD = 8,

		U8 = 1,
		U16 = 2,
		U32 = 4,
		U64 = 8,

		Auto = 255
	}
}
