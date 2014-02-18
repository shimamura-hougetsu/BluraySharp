using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class PlStnRecord : IPlStnRecord
	{
		public PlStnStreamEntryType EntryType
		{
			get
			{
				return (this.entry != null) ? this.entry.EntryType : PlStnStreamEntryType.Unknown;
			}
			set
			{
				switch (value)
				{
					case PlStnStreamEntryType.PlayItem:
						this.entry = new PlStnPlayItemStreamEntryFields();
						break;
					case PlStnStreamEntryType.SubPlayItem:
						this.entry = new PlStnSubPlayItemStreamEntryFields();
						break;
					case PlStnStreamEntryType.InMuxPip:
						this.entry = new PlStnInMuxPipStreamEntryFields();
						break;
					default:
						this.entry = null;
						break;
				}
			}
		}

		internal PlStnStreamEntryFields entry = null;
		public IPlStnStreamEntry Entry
		{
			get
			{
				return this.entry;
			}
		}

		public virtual long SerializeTo(Architecture.IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public virtual long DeserializeFrom(Architecture.IBdRawReadContext context)
		{
			//Stream Entry
			//-byte tFieldLen = context.DeserializeByte();
			//-	context.EnterScope(tFieldLen);
			try
			{
				//-	this.EntryType = (PlStnStreamEntryType)context.DeserializeByte();
				if (this.Entry != null)
				{
					context.Deserialize(this.Entry);
				}
			}
			finally
			{
				context.ExitScope();
			}

			return context.Position;
		}

		public virtual long RawLength
		{
			get
			{
				return sizeof(byte) + sizeof(byte) + this.Entry.GetRawLength();
			}
		}
	}
}
