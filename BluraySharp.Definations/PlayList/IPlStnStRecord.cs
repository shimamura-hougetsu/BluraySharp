using BluraySharp.Common;
using BluraySharp.Serializing;

namespace BluraySharp.PlayList
{
	public interface IPlStnStRecord : IPlStnRecord
	{
		BdStCodingType CodingType { get; set; }
		IPlStnStStreamAttribute Attribute { get; }
	}
}
