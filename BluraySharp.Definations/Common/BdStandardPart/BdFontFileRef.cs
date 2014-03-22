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
using System;

namespace BluraySharp.Common.BdStandardPart
{
	public class BdFontFileRef : BdPart
	{
		#region FontIdString

		[BdStringField(5, Common.BdCharacterCodingType.UTF8)]
		private string FontIdString
		{
			get { return this.FontId.ToString("00000"); }
			set { this.FontId = uint.Parse(value); }
		}
		public uint FontId { get; set; }

		#endregion

		public override string ToString()
		{
			return string.Format("FontRef: {0}.otf", this.FontIdString);
		}
	}
}
