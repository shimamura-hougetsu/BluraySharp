using System;
using System.Collections.Generic;
using BluraySharp.Common;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public class PlStnTable: IBdPart, IPlStnTable
	{
		public long SerializeTo(IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			ushort tDataLen;

			tDataLen = context.DeserializeUInt16();
			context.EnterScope(tDataLen);

			try
			{
				//this.ReservedForFutureUse = context.DeserializeUInt16();

				//byte[] tRecordCount = context.DeserializeBytes((int)PlStnRecordTypes.Count);

				//for (int iType = 0; iType < (int)PlStnRecordTypes.Count; iType++)
				//{
				//    recordTables[iType] = new List<PlStnRecord>();
				//    for (int iCount = 0; iCount < tRecordCount[iType]; iCount++)
				//    {
				//        recordTables[iType].Add(context.Deserialize<PlStnRecord>());
				//    }
				//}
			}
			finally
			{
				context.ExitScope();
			}

			return context.Position;
		}

		public long RawLength
		{
			get
			{
				long tDataLen = sizeof(ushort);
				tDataLen += sizeof(ushort);


				return tDataLen;
			}
		}

		public IList<IPlStnViRecord> VStream
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public IList<IPlStnAuRecord> AStreams
		{
			get { throw new NotImplementedException(); }
		}

		public IList<IPlStnOlRecord> PgTsStreams
		{
			get { throw new NotImplementedException(); }
		}

		public IList<IPlStnSecViRecord> SvStreams
		{
			get { throw new NotImplementedException(); }
		}

		public IList<IPlStnSecAuRecord> SaStreams
		{
			get { throw new NotImplementedException(); }
		}


		public IList<IPlStnOlRecord> IgStreams
		{
			get { throw new NotImplementedException(); }
		}

		public IList<IPlStnOlRecord> PipPgTsStreams
		{
			get { throw new NotImplementedException(); }
		}
	}
}
