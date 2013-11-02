﻿using System;
using System.Collections.Generic;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlStnTable: IBdRawSerializable
	{
		private List<PlStnRecord>[] _RecordTables = new List<PlStnRecord>[(int)StnRecordTypes.Count];
		private ushort Reserved { get; set; }

		public IList<PlStnRecord> this[StnRecordTypes index]
		{
			get
			{
				return _RecordTables[(int) index];
			}
		}

		public long SerializeTo(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			ushort tDataLen;

			tDataLen = context.DeserializeUInt16();
			context.EnterScope(tDataLen);

			try
			{
				Reserved = context.DeserializeUInt16();

				byte[] tRecordCount = context.DeserializeBytes((int)StnRecordTypes.Count);

				for (int iType = 0; iType < (int)StnRecordTypes.Count; iType++)
				{
					_RecordTables[iType] = new List<PlStnRecord>();
					for (int iCount = 0; iCount < tRecordCount[iType]; iCount++)
					{
						_RecordTables[iType].Add(context.Deserialize<PlStnRecord>());
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
			get { 
				long tDataLen = sizeof(ushort);
				tDataLen += sizeof(ushort);

				foreach(IBdRawSerializable tObj in _RecordTables)
				{
					tDataLen += tObj.RawLength;
				}

				return tDataLen;
			}
		}
	}
}
