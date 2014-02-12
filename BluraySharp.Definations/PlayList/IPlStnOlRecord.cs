using BluraySharp.Common;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public interface IPlStnOlRecord : IPlStnRecord
	{
		BdPgTsCodingType CodingType { get; set; }
		IPlStnAltStreamAttribute Attributes { get; }
	}
}
