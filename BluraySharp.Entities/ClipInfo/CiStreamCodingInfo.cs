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

namespace BluraySharp.ClipInfo
{
	[BdPartScope(BdIntSize.U8)]
	internal class CiStreamCodingInfo : BdPart
	{
		public CiStreamCodingInfo()
		{
			this.CodingType = BdStreamCodingType.Unknown;
		}

		#region CodingType

		private BdStreamCodingType codingType;

		[BdUIntField(BdIntSize.U8)]
		public BdStreamCodingType CodingType
		{
			get { return this.codingType; }
			set { this.UpdateAttr(this.codingType = value); }
		}

		private void UpdateAttr(BdStreamCodingType codingType)
		{
			switch(codingType)
			{
				case BdStreamCodingType.ViAvc:
				case BdStreamCodingType.ViMvc:
				case BdStreamCodingType.ViMpeg1:
				case BdStreamCodingType.ViMpeg2:
				case BdStreamCodingType.ViVc1:
					this.codingAttr = new CiStreamViAttrInfo();
					break;

				case BdStreamCodingType.AuDolby:
				case BdStreamCodingType.AuDolbyLossless:
				case BdStreamCodingType.AuDolbyPlus:

				case BdStreamCodingType.AuDts:
				case BdStreamCodingType.AuDtsHDHR:
				case BdStreamCodingType.AuDtsHDMA:

				case BdStreamCodingType.AuLPCM:
				case BdStreamCodingType.AuMpeg1:
				case BdStreamCodingType.AuMpeg2:
					this.codingAttr = new CiStreamAuAttrInfo();
					break;

				case BdStreamCodingType.GxInterractive:
				case BdStreamCodingType.GxPresentation:
					this.codingAttr = new CiStreamGxAttrInfo();
					break;

				case BdStreamCodingType.TxSubtitle:
					this.codingAttr = new CiStreamTxAttrInfo();
					break;

				default:
					this.codingAttr = new CiStreamNaAttrInfo();
					break;
			}
		}

		#endregion

		#region CodingAttr(Variable)

		private ICiStreamAttrInfo codingAttr = null;

		[BdSubPartField]
		public ICiStreamAttrInfo CodingAttr
		{
			get { return this.codingAttr; }
		}

		#endregion

		public override string ToString()
		{
			return "CodingInfo for stream. An internal class.";
		}
	}
}
