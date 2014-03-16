using BluraySharp.Common.BdPartFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BluraySharp.Common.BdStandardPart
{
	public class BdLangCode : BdPart
	{
		private string isoLangCode = CultureInfo.CurrentUICulture.ThreeLetterISOLanguageName;

		[BdStringField(3, BdCharacterCodingType.UTF8)]
		public string IsoLangCode
		{
			get { return this.isoLangCode; }
			private set { this.isoLangCode = value; }
		}

		public BdLang Value
		{
			get { return this.ToBdLang(); }
			set { this.IsoLangCode = value.ToIsoLangCode(); }
		}

		public static implicit operator BdLang(BdLangCode langCode)
		{
			return langCode.Value;
		}

		public static implicit operator string(BdLangCode langCode)
		{
			return langCode.IsoLangCode;
		}

		public static implicit operator BdLangCode(string langCodeString)
		{
			return new BdLangCode() { IsoLangCode = langCodeString };
		}

		public static implicit operator BdLangCode(BdLang langValue)
		{
			return new BdLangCode() { Value = langValue };
		}

		public override string ToString()
		{
			return this.Value.ToStringLocalized();
		}

	}
}
