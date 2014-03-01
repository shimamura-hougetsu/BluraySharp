using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common.BdPartRawIoHelper
{
	internal class BdStringFieldAttribute : BdFieldAttribute
	{
		public int ByteCount { get; private set; }
		public Encoding Encoding { get; private set; }

		public BdStringFieldAttribute(int byteCount, Encoding encoding)
			: base(BdFieldType.String)
		{
			this.ByteCount = byteCount;
			this.Encoding = encoding;
		}
	}
}
