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

namespace BluraySharp.PlayList
{
	public class PlStnTxAttrInfo : BdPart, IPlStnTxAttrInfo
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
			return "STN Graphics AttrInfo";
		}
	}
}
