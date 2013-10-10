using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class StnTable: IBdRawSerializable
	{
		private List<StnRecord>[] _RecordTables = new List<StnRecord>[(int)StnRecordTypes.Count];
		private ushort Reserved { get; set; }

		public IList<StnRecord> this[StnRecordTypes index]
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
					_RecordTables[iType] = new List<StnRecord>();
					for (int iCount = 0; iCount < tRecordCount[iType]; iCount++)
					{
						_RecordTables[iType].Add(context.Deserialize<StnRecord>());
					}
				}
			}
			finally
			{
				context.ExitScope();
			}

			return context.Offset += tDataLen;
		}

		public long Length
		{
			get { throw new NotImplementedException(); }
		}
	}

	public enum StnRecordTypes: byte
	{
		Video = 0,
		Audio = 1,
		Pg = 2,
		Ig = 3,
		AudioAlt = 4,
		VideoAlt = 5,
		PipPg = 6,
		Reserved1 = 7,
		Reserved2 = 8,
		Reserved3 = 9,
		Reserved4 = 10,
		Reserved5 = 11,
		Count
	}
}
