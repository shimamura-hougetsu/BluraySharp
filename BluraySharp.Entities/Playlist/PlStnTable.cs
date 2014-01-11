using System;
using System.Collections.Generic;
using BluraySharp.Common;

namespace BluraySharp.Playlist
{
	public class PlStnTable: IBdObject, IPlStnTable
	{
		private List<PlStnRecord>[] recordTables = new List<PlStnRecord>[(int)PlStnRecordTypes.Count];
		private ushort ReservedForFutureUse { get; set; }

		IList<IPlStnRecord> IPlStnTable.this[PlStnRecordTypes index]
		{
			get { throw new NotImplementedException(); }
		}

		public IList<PlStnRecord> this[PlStnRecordTypes index]
		{
			get
			{
				return recordTables[(int) index];
			}
		}

		public long SerializeTo(IBdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawSerializeContext context)
		{
			ushort tDataLen;

			tDataLen = context.DeserializeUInt16();
			context.EnterScope(tDataLen);

			try
			{
				this.ReservedForFutureUse = context.DeserializeUInt16();

				byte[] tRecordCount = context.DeserializeBytes((int)PlStnRecordTypes.Count);

				for (int iType = 0; iType < (int)PlStnRecordTypes.Count; iType++)
				{
					recordTables[iType] = new List<PlStnRecord>();
					for (int iCount = 0; iCount < tRecordCount[iType]; iCount++)
					{
						recordTables[iType].Add(context.Deserialize<PlStnRecord>());
					}
				}
			}
			finally
			{
				context.ExitScope();
			}

			return context.Offset += tDataLen;
		}

		public long RawLength
		{
			get
			{
				long tDataLen = sizeof(ushort);
				tDataLen += sizeof(ushort);

				foreach (IBdObject tObj in recordTables)
				{
					tDataLen += tObj.RawLength;
				}

				return tDataLen;
			}
		}
	}
}
