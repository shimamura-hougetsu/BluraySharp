using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public abstract class PlStnStreamEntryFields : IPlStnStreamEntry
	{
		internal PlStnStreamEntryType EntryType { get; private set; }

		public PlStnStreamEntryFields(PlStnStreamEntryType type)
		{
			this.EntryType = type;
		}

		public abstract long SerializeTo(Architecture.IBdRawWriteContext context);
		public abstract  long DeserializeFrom(Architecture.IBdRawReadContext context);
		public abstract long RawLength { get; }
	}
}
