using BluraySharp.Common;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public interface IPlStnStRecord : IPlStnRecord
	{
		BdStCodingType CodingType { get; set; }
		IPlStnStStreamAttribute Attribute { get; }
	}
}
