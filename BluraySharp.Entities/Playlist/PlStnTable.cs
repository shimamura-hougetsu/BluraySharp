using System;
using System.Collections.Generic;
using BluraySharp.Common;
using BluraySharp.Architecture;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	[BdPartScope(BdIntSize.U16)]
	public class PlStnTable : BdPart, IPlStnTable
	{
		#region ReservedForFutureUse1

		[BdUIntField(BdIntSize.U16)]
		private ushort ReservedForFutureUse1 { get; set; }

		#endregion

		#region EntryCounts

		[BdUIntField(BdIntSize.U8)]
		private byte ViStreamsCount
		{
			get { return (byte)this.viStreams.Count; }
			set { this.viStreams.SetCount(value); }
		}

		[BdUIntField(BdIntSize.U8)]
		private byte AuStreamsCount
		{
			get { return (byte)this.auStreams.Count; }
			set { this.auStreams.SetCount(value); }
		}

		[BdUIntField(BdIntSize.U8)]
		private byte StStreamsCount
		{
			get { return (byte)this.stStreams.Count; }
			set { this.stStreams.SetCount(value); }
		}

		[BdUIntField(BdIntSize.U8)]
		private byte IgStreamsCount
		{
			get { return (byte)this.igStreams.Count; }
			set { this.igStreams.SetCount(value); }
		}

		[BdUIntField(BdIntSize.U8)]
		private byte SaStreamsCount
		{
			get { return (byte)this.saStreams.Count; }
			set { this.saStreams.SetCount(value); }
		}

		[BdUIntField(BdIntSize.U8)]
		private byte SvStreamsCount
		{
			get { return (byte)this.svStreams.Count; }
			set { this.svStreams.SetCount(value); }
		}

		[BdUIntField(BdIntSize.U8)]
		private byte PipStStreamsCount
		{
			get { return (byte)this.pipStStreams.Count; }
			set { this.pipStStreams.SetCount(value); }
		}

		#endregion

		#region ReservedForFutureUse2

		private byte[] reservedForFutureUse2 = new byte[5];
		[BdByteArrayField]
		private byte[] ReservedForFutureUse2
		{
			get { return this.reservedForFutureUse2; }
		}


		#endregion

		#region Entry Lists

		private BdList<PlStnViEntry, IPlStnViEntry> viStreams =
			new BdList<PlStnViEntry, IPlStnViEntry>(1) { new PlStnViEntry() };

		[BdSubPartField]
		public IBdList<IPlStnViEntry> ViStreams
		{
			get { return this.viStreams; }
		}

		private BdList<PlStnAuEntry, IPlStnAuEntry> auStreams =
			new BdList<PlStnAuEntry, IPlStnAuEntry>(32);

		[BdSubPartField]
		public IBdList<IPlStnAuEntry> AuStreams
		{
			get { return this.auStreams; }
		}
		
		private BdList<PlStnStEntry, IPlStnStEntry> stStreams =
			new BdList<PlStnStEntry, IPlStnStEntry>(255);

		[BdSubPartField]
		public IBdList<IPlStnStEntry> StStreams
		{
			get { return this.stStreams; }
		}

		private BdList<PlStnStEntry, IPlStnStEntry> pipStStreams =
			new BdList<PlStnStEntry, IPlStnStEntry>(32);

		[BdSubPartField]
		public IBdList<IPlStnStEntry> PipStStreams
		{
			get { return this.pipStStreams; }
		}

		private BdList<PlStnIgEntry, IPlStnIgEntry> igStreams =
			new BdList<PlStnIgEntry, IPlStnIgEntry>(32);

		[BdSubPartField]
		public IBdList<IPlStnIgEntry> IgStreams
		{
			get { return this.igStreams; }
		}

		private BdList<PlStnSaEntry, IPlStnSaEntry> saStreams =
			new BdList<PlStnSaEntry, IPlStnSaEntry>(32);


		[BdSubPartField]
		public IBdList<IPlStnSaEntry> SaStreams
		{
			get { return this.saStreams; }
		}

		private BdList<PlStnSvEntry, IPlStnSvEntry> svStreams =
			new BdList<PlStnSvEntry, IPlStnSvEntry>(32);

		[BdSubPartField]
		public IBdList<IPlStnSvEntry> SvStreams
		{
			get { return this.svStreams; }
		}

		#endregion
		
		public override string ToString()
		{
			return "STN Table";
		}
	}
}
