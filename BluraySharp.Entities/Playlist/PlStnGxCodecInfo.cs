using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public class PlStnGxCodecInfo : BdPart, IPlStnGxCodecInfo
	{
		#region Language

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
