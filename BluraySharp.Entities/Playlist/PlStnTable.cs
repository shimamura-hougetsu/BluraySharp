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
		private byte ViEntriesCount
		{
			get { return (byte)this.viEntries.Count; }
			set { this.viEntries.SetCount(value); }
		}

		[BdUIntField(BdIntSize.U8)]
		private byte AuEntriesCount
		{
			get { return (byte)this.auEntries.Count; }
			set { this.auEntries.SetCount(value); }
		}

		[BdUIntField(BdIntSize.U8)]
		private byte StEntriesCount
		{
			get { return (byte)this.stEntries.Count; }
			set { this.stEntries.SetCount(value); }
		}

		[BdUIntField(BdIntSize.U8)]
		private byte IgEntriesCount
		{
			get { return (byte)this.igEntries.Count; }
			set { this.igEntries.SetCount(value); }
		}

		[BdUIntField(BdIntSize.U8)]
		private byte SaEntriesCount
		{
			get { return (byte)this.saEntries.Count; }
			set { this.saEntries.SetCount(value); }
		}

		[BdUIntField(BdIntSize.U8)]
		private byte SvEntriesCount
		{
			get { return (byte)this.svEntries.Count; }
			set { this.svEntries.SetCount(value); }
		}

		[BdUIntField(BdIntSize.U8)]
		private byte PipStEntriesCount
		{
			get { return (byte)this.pipStEntries.Count; }
			set { this.pipStEntries.SetCount(value); }
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

		private BdList<PlStnViEntry, IPlStnViEntry> viEntries =
			new BdList<PlStnViEntry, IPlStnViEntry>(1) { new PlStnViEntry() };

		[BdSubPartField]
		public IBdList<IPlStnViEntry> ViEntries
		{
			get { return this.viEntries; }
		}

		private BdList<PlStnAuEntry, IPlStnAuEntry> auEntries =
			new BdList<PlStnAuEntry, IPlStnAuEntry>(32);

		[BdSubPartField]
		public IBdList<IPlStnAuEntry> AuEntries
		{
			get { return this.auEntries; }
		}
		
		private BdList<PlStnStEntry, IPlStnStEntry> stEntries =
			new BdList<PlStnStEntry, IPlStnStEntry>(255);

		[BdSubPartField]
		public IBdList<IPlStnStEntry> StEntries
		{
			get { return this.stEntries; }
		}

		private BdList<PlStnStEntry, IPlStnStEntry> pipStEntries =
			new BdList<PlStnStEntry, IPlStnStEntry>(32);

		[BdSubPartField]
		public IBdList<IPlStnStEntry> PipStEntries
		{
			get { return this.pipStEntries; }
		}

		private BdList<PlStnIgEntry, IPlStnIgEntry> igEntries =
			new BdList<PlStnIgEntry, IPlStnIgEntry>(32);

		[BdSubPartField]
		public IBdList<IPlStnIgEntry> IgEntries
		{
			get { return this.igEntries; }
		}

		private BdList<PlStnSaEntry, IPlStnSaEntry> saEntries =
			new BdList<PlStnSaEntry, IPlStnSaEntry>(32);


		[BdSubPartField]
		public IBdList<IPlStnSaEntry> SaEntries
		{
			get { return this.saEntries; }
		}

		private BdList<PlStnSvEntry, IPlStnSvEntry> svEntries =
			new BdList<PlStnSvEntry, IPlStnSvEntry>(32);

		[BdSubPartField]
		public IBdList<IPlStnSvEntry> SvEntries
		{
			get { return this.svEntries; }
		}

		#endregion
		
		public override string ToString()
		{
			return "STN Table";
		}
	}
}
