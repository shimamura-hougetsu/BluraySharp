using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.Architecture;
using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public class PlStnTsCodecInfo : BdPart, IPlStnTsCodecInfo
	{
		private BdCharacterCodingType charCode = BdCharacterCodingType.UTF8;
		private BdLangCode language = BdLang.LANG_ENG;

		[BdUIntField(BdIntSize.U8)]
		public BdCharacterCodingType CharCode
		{
			get { return this.charCode; }
			set { this.charCode = value; }
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
			return "STN Text Subtitle CodecInfo";
		}
	}
}