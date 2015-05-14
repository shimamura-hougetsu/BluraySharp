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

namespace BluraySharp.ClipInfo
{
	public class CiStreamGxAttrInfo: BdPart, ICiStreamGxAttrInfo
	{
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

		[BdUIntField(BdIntSize.U8)]
		private byte ReservedForFutureUse { get; set; }

		#endregion

		#region ISRC

		private BdIsrcCode isrc = new BdIsrcCode();

		[BdSubPartField]
		public BdIsrcCode ISRC
		{
			get { return this.isrc; }
		}

		#endregion

		#region ReservedForFutureUse2

		[BdUIntField(BdIntSize.U32)]
		private uint ReservedForFutureUse2 { get; set; }

		#endregion

		public override string ToString()
		{
			return "Graphics Stream Attributes.";
		}
	}
}
