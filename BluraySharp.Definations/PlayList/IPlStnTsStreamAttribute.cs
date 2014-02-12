using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public interface IPlStnTsStreamAttribute : IPlStnAltStreamAttribute
	{
		BdCharacterCodingType CharCode { get; set; }
	}
}
