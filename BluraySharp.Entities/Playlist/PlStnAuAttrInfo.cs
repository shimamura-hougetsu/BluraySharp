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
using BluraySharp.Common.BdStandardPart;
using System;

namespace BluraySharp.PlayList
{
	public class PlStnAuAttrInfo : BdPart, IPlStnAuAttrInfo
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
