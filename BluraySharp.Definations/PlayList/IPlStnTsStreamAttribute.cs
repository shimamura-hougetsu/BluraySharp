using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnTsStreamAttribute : IPlStnStStreamAttribute
	{
		BdLang Language { get; set; }
		BdCharacterCodingType CharCode { get; set; }
	}
}
