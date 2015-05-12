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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BluraySharp.ClipInfo
{
	public class BdClpi : BdPart, IBdClpi
	{
		#region ClpiMark

		private const string ClpiMarkConst = "HDMV";
		private string clpiMark = BdClpi.ClpiMarkConst;

		[BdStringField(4, Common.BdCharacterCodingType.UTF8)]
		public string ClpiMark
		{
			get { return this.clpiMark; }
			set
			{
				Debug.Assert(value == BdClpi.ClpiMarkConst);
				this.clpiMark = value;
			}
		}
		#endregion

		#region ClpiVer

		private static readonly string[] ClpiVers = new string[] { "0100", "0200" };
		private string clpiVer = BdClpi.ClpiVers[1];

		[BdStringField(4, Common.BdCharacterCodingType.UTF8)]
		public string ClpiVer
		{
			get { return this.clpiVer; }
			set
			{
				Debug.Assert(BdClpi.ClpiVers.Contains(value));
				this.clpiVer = value;
			}
		}

		#endregion


		#region SequenceInfoOfs

		private bool sequenceInfoSkip = false;
		public bool SequenceInfoSkip
		{
			get { return this.sequenceInfoSkip; }
			set
			{
				if (this.sequenceInfoSkip != value)
				{
					if (this.sequenceInfoSkip = value)
					{
						this.sequenceInfo = null;
						this.sequenceInfoOfs = 0;
					}
					else
					{
						this.sequenceInfo = new CiSequenceInfo();
					}
				}
			}
		}

		private uint sequenceInfoOfs = 0;

		[BdUIntField(BdIntSize.U32)]
		public uint PlayItemListOfs
		{
			get { return this.sequenceInfoOfs; }
			set
			{
				this.SequenceInfoSkip =
					((this.sequenceInfoOfs = value) == 0);
			}
		}

		#endregion

		#region ProgramInfoOfs

		private bool programInfoSkip = false;
		public bool ProgramInfoSkip
		{
			get { return this.programInfoSkip; }
			set
			{
				if (this.programInfoSkip != value)
				{
					if (this.programInfoSkip = value)
					{
						this.programInfo = null;
						this.programInfoOfs = 0;
					}
					else
					{
						this.programInfo = new CiProgramInfo();
					}
				}
			}
		}

		private uint programInfoOfs = 0;

		[BdUIntField(BdIntSize.U32)]
		public uint ProgramInfoOfs
		{
			get { return this.programInfoOfs; }
			set
			{
				this.ProgramInfoSkip =
					((this.programInfoOfs = value) == 0);
			}
		}

		#endregion

		#region CpiOfs

		private bool cpiSkip = false;
		public bool CpiSkip
		{
			get { return this.cpiSkip; }
			set
			{
				if (this.cpiSkip != value)
				{
					if (this.cpiSkip = value)
					{
						this.cpi = null;
						this.cpiOfs = 0;
					}
					else
					{
						this.cpi = new CiCpi();
					}
				}
			}
		}

		private uint cpiOfs = 0;

		[BdUIntField(BdIntSize.U32)]
		public uint CpiOfs
		{
			get { return this.cpiOfs; }
			set
			{
				this.CpiSkip =
					((this.cpiOfs = value) == 0);
			}
		}

		#endregion

		#region ClipMarkOfs

		private bool clipMarkSkip = false;
		public bool ClipMarkSkip
		{
			get { return this.clipMarkSkip; }
			set
			{
				if (this.clipMarkSkip != value)
				{
					if (this.clipMarkSkip = value)
					{
						this.clipMark = null;
						this.clipMarkOfs = 0;
					}
					else
					{
						this.clipMark = new CiClipMark();
					}
				}
			}
		}

		private uint clipMarkOfs = 0;

		[BdUIntField(BdIntSize.U32)]
		public uint ClipMarkOfs
		{
			get { return this.clipMarkOfs; }
			set
			{
				this.ClipMarkSkip =
					((this.clipMarkOfs = value) == 0);
			}
		}

		#endregion

		#region ExtensionDataOfs

		private bool extensionDataSkip = true;
		public bool ExtensionDataSkip
		{
			get { return this.extensionDataSkip; }
			set
			{
				if (this.extensionDataSkip != value)
				{
					if (this.extensionDataSkip = value)
					{
						this.extensionData = null;
						this.extensionDataOfs = 0;
					}
					else
					{
						this.extensionData = new BdExtensionData();
					}
				}
			}
		}

		private uint extensionDataOfs = 0;

		[BdUIntField(BdIntSize.U32)]
		public uint ExtensionDataOfs
		{
			get { return this.extensionDataOfs; }
			set
			{
				this.ExtensionDataSkip =
					((this.extensionDataOfs = value) == 0);
			}
		}

		#endregion

		#region ReserevedForFutureUse

		private byte[] reserevedForFutureUse = new byte[12];

		[BdByteArrayField]
		public byte[] ReserevedForFutureUse
		{
			get { return this.reserevedForFutureUse; }
		}

		#endregion

		#region AppInfo

		private CiClipInfo clipInfo = new CiClipInfo();

		[BdSubPartField]
		public ICiClipInfo ClipInfo
		{
			get { return this.clipInfo; }
		}

		#endregion

		#region SequenceInfo

		private CiSequenceInfo sequenceInfo = new CiSequenceInfo();

		[BdSubPartField(SkipIndicator = "SequenceInfoSkip", OffsetIndicator = "SequenceInfoOfs")]
		public ICiSequenceInfo SequenceInfo
		{
			get { return this.sequenceInfo; }
		}

		#endregion

		#region ProgramInfo

		private CiProgramInfo programInfo = new CiProgramInfo();

		[BdSubPartField(SkipIndicator = "ProgramInfoSkip", OffsetIndicator = "ProgramInfoOfs")]
		public ICiProgramInfo ProgramInfo
		{
			get { return this.programInfo; }
		}

		#endregion

		#region Cpi

		private CiCpi cpi = new CiCpi();

		[BdSubPartField(SkipIndicator = "CpiSkip", OffsetIndicator = "CpiOfs")]
		public ICiCpi Cpi
		{
			get { return this.cpi; }
		}

		#endregion
		
		#region ClipMark

		private CiClipMark clipMark = new CiClipMark();

		[BdSubPartField(SkipIndicator = "ClipMarkSkip", OffsetIndicator = "ClipMarkOfs")]
		public ICiClipMark ClipMark
		{
			get { return this.clipMark; }
		}

		#endregion

		#region ExtensionData

		private BdExtensionData extensionData = null;

		[BdSubPartField(SkipIndicator = "ExtensionDataSkip", OffsetIndicator = "ExtensionDataOfs")]
		public BdExtensionData ExtensionData
		{
			get { return this.extensionData; }
			set
			{
				this.ExtensionDataSkip = (this.extensionData = value).IsNull();
			}
		}

		#endregion

		public override string ToString()
		{
			return "Bluray CLPI(Clip Info) file.";
		}
	}
}
