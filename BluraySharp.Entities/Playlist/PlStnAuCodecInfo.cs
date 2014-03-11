using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;
using System;

namespace BluraySharp.PlayList
{
	public class PlStnAuCodecInfo : BdPart, IPlStnAuCodecInfo
	{
		private BdBitwise8 formatValue = new BdBitwise8();
		private BdLangCode language = BdLang.LANG_ENG;

		[BdSubPartField]
		private BdBitwise8 FormatValue
		{
			get { return this.formatValue; }
		}
		public BdAuPresentationType Presentation
		{
			get { return (BdAuPresentationType)this.FormatValue[4, 4]; }
			set { this.FormatValue[4, 4] = (byte)value; }
		}

		public BdAuSampleRate SampleFrequency
		{
			get { return (BdAuSampleRate)this.FormatValue[4, 4]; }
			set { this.FormatValue[4, 4] = (byte)value; }
		}

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

		public override string ToString()
		{
			return "STN Audio CodecInfo";
		}
	}
}
