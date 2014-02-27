using BluraySharp.Common;
using BluraySharp.Serializing;

namespace BluraySharp.PlayList
{
	public interface IPlStnIgRecord : IPlStnRecord
	{
		BdIgCodingType CodingType { get; set; }
		BdLang Language { get; set; }
	}
}
