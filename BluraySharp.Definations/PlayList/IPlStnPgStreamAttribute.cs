using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnPgStreamAttribute : IPlStnStStreamAttribute
	{
		BdLang Language { get; set; }
	}
}
