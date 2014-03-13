
using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public class PlStnTxCodecInfo : BdPart, IPlStnTxCodecInfo
	{
		#region CharCode

		[BdUIntField(BdIntSize.U8)]
		public BdCharacterCodingType CharCode { get; set; }

		#endregion

		#region Language

		private BdLangCode language = new BdLangCode();

		[BdSubPartField]
		public BdLangCode LanguageCode
		{
			get { return this.language; }
		}
		public BdLang Language
		{
			get { return this.language; }
			set { this.language = value; }
		}

		#endregion

		#region ReservedForFutureUse
		private byte[] reservedForFutureUse = new byte[1];

		[BdByteArrayField]
		private byte[] ReservedForFutureUse
		{
			get { return this.reservedForFutureUse; }
		}

		#endregion

		public override string ToString()
		{
			return "STN Graphics CodecInfo";
		}
	}
}
