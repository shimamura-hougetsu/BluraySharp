using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;
using System;

namespace BluraySharp.PlayList
{
	public class PlStnAuAttrInfo : BdPart, IPlStnAuAttribInfo
	{
		#region FormatValue

		private BdBitwise8 formatOptions = new BdBitwise8();

		[BdSubPartField]
		private BdBitwise8 FormatOptions
		{
			get { return this.formatOptions; }
		}
		public BdAuPresentationType Presentation
		{
			get { return (BdAuPresentationType)this.FormatOptions[4, 4]; }
			set { this.FormatOptions[4, 4] = (byte)value; }
		}

		public BdAuSampleRate SampleFrequency
		{
			get { return (BdAuSampleRate)this.FormatOptions[4, 4]; }
			set { this.FormatOptions[4, 4] = (byte)value; }
		}

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

		public override string ToString()
		{
			return "STN Audio AttrInfo";
		}
	}
}
