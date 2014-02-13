using BluraySharp.Common;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public interface IPlStnIgRecord : IPlStnRecord
	{
		BdIgCodingType CodingType { get; set; }
		BdLang Language { get; set; }
	}
}
