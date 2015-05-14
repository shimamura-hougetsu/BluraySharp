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

namespace BluraySharp.ClipInfo
{
	public class CiStreamViAttrInfo: BdPart, ICiStreamViAttrInfo
	{
		#region CodingAttr

		private BdBitwise16 codingAttrOptions = new BdBitwise16(0);

		[BdSubPartField]
		private BdBitwise16 CodingAttr
		{
			get
			{
				return this.codingAttrOptions;
			}
			set
			{
				this.codingAttrOptions.Value = value.Value;
			}
		}
		public BdViFormat Format
		{
			get { return (BdViFormat)this.codingAttrOptions[12, 4]; }
			set { this.codingAttrOptions[12, 4] = (ushort)value; }
		}
		public BdViFrameRate FrameRate
		{
			get { return (BdViFrameRate)this.codingAttrOptions[8, 4]; }
			set { this.codingAttrOptions[8, 4] = (ushort)value; }
		}
		public BdViAspectRatio AspectRatio
		{
			get { return (BdViAspectRatio)this.codingAttrOptions[4, 4]; }
			set { this.codingAttrOptions[4, 4] = (ushort)value; }
		}
		public bool CcFlag
		{
			get { return this.codingAttrOptions[2, 1] == 1; }
			set { this.codingAttrOptions[2, 1] = (ushort)(value ? 1 : 0); }
		}

		#endregion

		#region ReservedForFutureUse

		[BdUIntField(BdIntSize.U16)]
		private uint ReservedForFutureUse { get; set; }

		#endregion

		#region ISRC

		private BdIsrcCode isrc = new BdIsrcCode();

		[BdSubPartField]
		public BdIsrcCode ISRC
		{
			get { return this.isrc; }
		}

		#endregion

		#region ReservedForFutureUse2

		[BdUIntField(BdIntSize.U32)]
		private uint ReservedForFutureUse2 { get; set; }

		#endregion

		public override string ToString()
		{
			return "Video Stream Attributes";
		}
	}
}
