using BluraySharp.Common;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public interface IPlStnPgTsRecord : IPlStnRecord
	{
		BdPgTsCodingType CodingType { get; set; }
		IPlStnStreamAttribute Attributes { get; }
	}
}
