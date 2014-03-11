using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public class PlStnPgCodecInfo : BdPart, IPlStnPgCodecInfo
	{
		private BdLangCode language = BdLang.LANG_ENG;
		private byte[] reservedForFutureUse = new byte[1];

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

		[BdByteArrayField]
		private byte[] ReservedForFutureUse
		{
			get { return this.reservedForFutureUse; }
		}

		public override string ToString()
		{
			return "STN Presentation Graphics CodecInfo";
		}
	}
}
