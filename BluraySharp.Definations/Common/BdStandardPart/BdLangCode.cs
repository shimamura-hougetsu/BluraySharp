/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at Google Code (https://code.google.com/p/bluray-sharp/)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/

using BluraySharp.Common.BdPartFramework;
using System.Globalization;

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
			get { return this.IsoLangCode.ToBdLang(); }
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
