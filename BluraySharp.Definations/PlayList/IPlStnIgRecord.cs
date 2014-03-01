using BluraySharp.Common;
using BluraySharp.Common.Serializing;

namespace BluraySharp.PlayList
{
	public interface IPlStnIgRecord : IPlStnRecord
	{
		BdIgCodingType CodingType { get; set; }
		BdLang Language { get; set; }
	}
}
