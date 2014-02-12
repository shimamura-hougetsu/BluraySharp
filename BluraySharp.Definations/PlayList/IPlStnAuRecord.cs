using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Common;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public interface IPlStnAuRecord : IPlStnRecord
	{
		BdAuCodingType CodingType { get; set; }
		IPlStnStreamAttribute Attributes { get; }
	}
}
