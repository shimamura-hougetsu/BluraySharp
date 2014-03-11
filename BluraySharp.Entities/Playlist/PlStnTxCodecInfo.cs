
using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public class PlStnTxCodecInfo : BdPart, IPlStnTxCodecInfo
	{

		[BdUIntField(BdIntSize.U8)]
		public BdCharacterCodingType CharCode { get; set; }



		private BdLangCode language = BdLang.LANG_ENG;

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

		private byte[] reservedForFutureUse = new byte[1];


		[BdByteArrayField]
		private byte[] ReservedForFutureUse
		{
			get { return this.reservedForFutureUse; }
		}

		public override string ToString()
		{
			return "STN Graphics CodecInfo";
		}
	}
}
