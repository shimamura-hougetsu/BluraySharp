using BluraySharp.Common;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public interface IPlStnOlRecord : IPlStnRecord
	{
		BdOlCodingType CodingType { get; set; }
		IPlStnOlStreamAttribute Attributes { get; }
	}
}
