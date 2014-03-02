using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharpTest
{
	public class TestClass : BdPart
	{
		private string mplsMark = "MPLS";
		private string mplsVer = "0200";
		private uint playListOfs = 0;
		private uint playMarkOfs = 0;
		private uint extDataOfs = 0;
		private byte[] reservedForFutureUse = new byte[20];
		private BdExtensionData appInfoSeg = new BdExtensionData();
		private BdExtensionData playListSeg = new BdExtensionData();
		private BdExtensionData playMarkSeg = new BdExtensionData();
		private BdExtensionData extDataSeg = new BdExtensionData();

		[BdStringField(4, BdCharacterCodingType.UTF8)]
		public string MplsMark
		{
			get { return this.mplsMark; }
			set { this.mplsMark = value; }
		}

		[BdStringField(4, BdCharacterCodingType.UTF8)]
		public string MplsVer
		{
			get { return this.mplsVer; }
			set { this.mplsVer = value; }
		}

		[BdUIntField(BdIntSize.U32)]
		public uint PlayListOfs
		{
			get
			{
				return this.playListOfs;
			}
			set
			{
				this.playListOfs = value;

				if (this.playListOfs == 0 && this.PlayListSeg != null)
				{
					this.PlayListSeg = null;
				}

				if (this.playListOfs != 0 && this.PlayListSeg == null)
				{
					this.PlayListSeg = new BdExtensionData();
				}
			}
		}

		[BdUIntField(BdIntSize.U32)]
		public uint PlayMarkOfs
		{
			get
			{
				return this.playMarkOfs;
			}
			set
			{
				this.playMarkOfs = value;
				if (this.playMarkOfs == 0 && this.PlayMarkSeg != null)
				{
					this.PlayMarkSeg = null;
				}

				if (this.playMarkOfs != 0 && this.PlayMarkSeg == null)
				{
					this.PlayMarkSeg = new BdExtensionData();
				}
			}
		}

		[BdUIntField(BdIntSize.U32)]
		public uint ExtDataOfs
		{
			get
			{
				return this.extDataOfs;
			}
			set
			{
				this.extDataOfs = value;
				if (this.extDataOfs == 0 && this.ExtDataSeg != null)
				{
					this.ExtDataSeg = null;
				}

				if (this.extDataOfs != 0 && this.ExtDataSeg == null)
				{
					this.ExtDataSeg = new BdExtensionData();
				}
			}
		}

		[BdByteArrayField]
		public byte[] ReservedForFutureUse
		{
			get { return this.reservedForFutureUse; }
			set { this.reservedForFutureUse = value; }
		}

		[BdSubPartField]
		public BdExtensionData AppInfoSeg
		{
			get { return this.appInfoSeg; }
			set { this.appInfoSeg = value; }
		}

		[BdFieldOffset("PlayListOfs")]
		[BdSubPartField]
		public BdExtensionData PlayListSeg
		{
			get { return this.playListSeg; }
			set { this.playListSeg = value; }
		}

		[BdFieldOffset("PlayMarkOfs")]
		[BdSubPartField]
		public BdExtensionData PlayMarkSeg
		{
			get { return this.playMarkSeg; }
			set { this.playMarkSeg = value; }
		}

		[BdFieldOffset("ExtDataOfs")]
		[BdSubPartField]
		public BdExtensionData ExtDataSeg
		{
			get { return this.extDataSeg; }
			set { this.extDataSeg = value; }
		}
		

		public override string ToString()
		{
			return "测试文件结构：mpls";
		}
	}
}
