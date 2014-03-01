using BluraySharp.Common;
using BluraySharp.Common.Serializing;

namespace BluraySharp.PlayList
{
	public interface IPlStnStRecord : IPlStnRecord
	{
		BdStCodingType CodingType { get; set; }
		IPlStnStStreamAttribute Attribute { get; }
	}
}
