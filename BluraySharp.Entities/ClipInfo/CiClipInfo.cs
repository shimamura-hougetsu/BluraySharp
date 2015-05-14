/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at BitBucket (https://bitbucket.org/subelf/bluraysharp)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/

using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;
using System;


namespace BluraySharp.ClipInfo
{
	[BdPartScope(BdIntSize.U32)]
	public class CiClipInfo : BdPart, ICiClipInfo
	{
		#region ReservedForFutureUse1

		[BdUIntField(BdIntSize.U16)]
		private ushort ReservedForFutureUse1 { get; set; }

		#endregion 

		#region StreamType

		private CiTsType streamType = CiTsType.Mpeg2Ts;

		[BdUIntField(BdIntSize.U8)]
		public CiTsType StreamType
		{
			get { return this.streamType; }
			set { this.streamType = value; }
		}

		#endregion

		#region ApplicationType

		private CiApplicationType appType = CiApplicationType.MainTsMovie;

		[BdUIntField(BdIntSize.U8)]
		public CiApplicationType ApplicationType
		{
			get { return this.appType; }
			set { this.appType = value; }
		}

		private const string AppFontRefListSkipIndicator = "AppFontRefListSkip";
		private bool AppFontRefListSkip
		{
			get { return this.ApplicationType != CiApplicationType.SubTsTextST; }
		}

		#endregion		
		
		#region ReservedForFutureUse2

		private byte[] reservedForFutureUse2 = new byte[3];

		[BdByteArrayField]
		private byte[] ReservedForFutureUse2 { get { return this.reservedForFutureUse2; } }

		#endregion 

		#region AtcOptions

		private BdBitwise8 atcOptions = new BdBitwise8(1);

		[BdSubPartField]
		private BdBitwise8 AtcOptions
		{
			get
			{
				this.AtcDeltaInfoSkip = (this.AtcDeltaList.Count == 0);
				return this.atcOptions;
			}
			set
			{
				this.atcOptions.Value = value.Value;
			}
		}

		private const string AtcDeltaInfoSkipIndicator = "AtcDeltaInfoSkip";
		private bool AtcDeltaInfoSkip
		{
			get { return this.atcOptions[0, 1] == 0; }
			set { this.atcOptions[0, 1] = (byte)(value ? 0 : 1); }
		}

		#endregion

		#region TsRecordingRate

		[BdUIntField(BdIntSize.U32)]
		public uint TsRecodingRate { get; set; }

		#endregion

		#region SourcePacketsCount

		[BdUIntField(BdIntSize.U32)]
		public uint SourcePacketsCount { get; set; }

		#endregion

		#region ReservedForFutureUse3

		private byte[] reservedForFutureUse3 = new byte[128];

		[BdByteArrayField]
		private byte[] ReservedForFutureUse3 { get { return this.reservedForFutureUse3; } }

		#endregion 

		#region TsTypeInfo

		private CiTsTypeInfo tsTypeInfo = new CiTsTypeInfo();

		[BdSubPartField]
		public ICiTsTypeInfo TsTypeInfo
		{
			get { return this.tsTypeInfo; }
		}

		#endregion
		


		#region AtcDeltaList

		[BdUIntField(BdIntSize.U8, SkipIndicator = AtcDeltaInfoSkipIndicator)]
		private byte ReservedForFutureUseAtcOpt { get; set; }

		[BdUIntField(BdIntSize.U8, SkipIndicator = AtcDeltaInfoSkipIndicator)]
		private byte AtcDeltaEntryCount
		{
			get { return (byte)this.atcDeltaList.Count; }
			set { this.atcDeltaList.SetCount(value); }
		}
		
		private BdList<CiAtcDeltaEntry, ICiAtcDeltaEntry> atcDeltaList
			= new BdList<CiAtcDeltaEntry, ICiAtcDeltaEntry>(0, 16);

		[BdSubPartField(SkipIndicator = AtcDeltaInfoSkipIndicator)]
		public IBdList<ICiAtcDeltaEntry> AtcDeltaList
		{
			get { return this.atcDeltaList; }
		}

		//
		//May be fields for muxing by ScenaristBD
		//
		//private BdList<uint, uint> presentationEndTime27MHz
		//	= new BdList<uint, uint>(0, 1);
		//
		//[BdUIntField(BdIntSize.U32, OptionalLength = 4)]
		//public IBdList<uint> PresentationEndTime27MHz { get { return this.presentationEndTime27MHz; } }
		//

		#endregion


		
		#region AppFontRefList

		[BdUIntField(BdIntSize.U8, SkipIndicator = AppFontRefListSkipIndicator)]
		private byte ReservedForFutureUseAppFontRef { get; set; }


		[BdUIntField(BdIntSize.U8, SkipIndicator = AppFontRefListSkipIndicator)]
		private byte AppFontRefEntryCount
		{
			get { return (byte)this.appFontRefList.Count; }
			set { this.appFontRefList.SetCount(value); }
		}

		private BdList<CiAppFontRef, ICiAppFontRef> appFontRefList
			= new BdList<CiAppFontRef, ICiAppFontRef>(0, 255);

		[BdUIntField(BdIntSize.U32, SkipIndicator = AppFontRefListSkipIndicator)]		
		public IBdList<ICiAppFontRef> AppFontRefList
		{
			get { return this.appFontRefList; }
		}

		#endregion



		public override string ToString()
		{
			return "ClipInfo";
		}
	}
}
