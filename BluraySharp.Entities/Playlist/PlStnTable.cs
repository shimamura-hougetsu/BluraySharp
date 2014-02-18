using System;
using System.Collections.Generic;
using BluraySharp.Common;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public class PlStnTable: IBdPart, IPlStnTable
	{
		public IBdList<IPlStnViRecord> ViStreams { get; internal set; }

		public IBdList<IPlStnAuRecord> AuStreams { get; internal set; }

		public IBdList<IPlStnStRecord> StStreams { get; internal set; }

		public IBdList<IPlStnIgRecord> IgStreams { get; internal set; }

		public IBdList<IPlStnSaRecord> SaStreams { get; internal set; }

		public IBdList<IPlStnSvRecord> SvStreams { get; internal set; }

		public IBdList<IPlStnStRecord> PipStStreams { get; internal set; }

		public ushort ReservedForFutureUse { get; private set; }

		public PlStnTable()
		{
			this.ViStreams = new BdPartList<PlStnViRecord, IPlStnViRecord>(1);
			this.AuStreams = new BdPartList<PlStnAuRecord, IPlStnAuRecord>(32);
			this.StStreams = new BdPartList<PlStnStRecord, IPlStnStRecord>(255);
			this.IgStreams = new BdPartList<PlStnIgRecord, IPlStnIgRecord>(32);
			this.SaStreams = new BdPartList<PlStnSaRecord, IPlStnSaRecord>(32);
			this.SvStreams = new BdPartList<PlStnSvRecord, IPlStnSvRecord>(32);
			this.PipStStreams = new BdPartList<PlStnStRecord, IPlStnStRecord>(32);
		}

		public long SerializeTo(IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			ushort tDataLen;

			//-tDataLen = context.DeserializeUInt16();
			//-context.EnterScope(tDataLen);

			try
			{
				//-this.ReservedForFutureUse = context.DeserializeUInt16();

				//-byte[] tRecordCount = context.Deserialize(12);

				//this.ViStreams.Clear();
				//for (int iRec = 0; iRec < tRecordCount[0]; ++iRec)
				//{
				//    this.ViStreams.Insert(context.Deserialize<PlStnViRecord>());
				//}

				//this.AuStreams.Clear();
				//for (int iRec = 0; iRec < tRecordCount[1]; ++iRec)
				//{
				//    this.AuStreams.Insert(context.Deserialize<PlStnAuRecord>());
				//}

				//this.StStreams.Clear();
				//for (int iRec = 0; iRec < tRecordCount[2]; ++iRec)
				//{
				//    this.StStreams.Insert(context.Deserialize<PlStnStRecord>());
				//}
				//this.PipStStreams.Clear();
				//for (int iRec = 0; iRec < tRecordCount[6]; ++iRec)
				//{
				//    this.PipStStreams.Insert(context.Deserialize<PlStnStRecord>());
				//}

				//this.IgStreams.Clear();
				//for (int iRec = 0; iRec < tRecordCount[3]; ++iRec)
				//{
				//    this.IgStreams.Insert(context.Deserialize<PlStnIgRecord>());
				//}

				//this.SaStreams.Clear();
				//for (int iRec = 0; iRec < tRecordCount[4]; ++iRec)
				//{
				//    this.SaStreams.Insert(context.Deserialize<PlStnSaRecord>());
				//}

				//this.SvStreams.Clear();
				//for (int iRec = 0; iRec < tRecordCount[5]; ++iRec)
				//{
				//    this.SvStreams.Insert(context.Deserialize<PlStnSvRecord>());
				//}

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
	}
}
