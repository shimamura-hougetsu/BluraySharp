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
